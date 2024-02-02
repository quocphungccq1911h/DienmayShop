using DienmayShop.Configurations.Constants;
using DienmayShop.Data.Entities;
using DienmayShop.Utilities.Extensions;
using DienmayShop.ViewModel.Common;
using DienmayShop.ViewModel.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DienmayShop.Application.System.Users
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IDistributedCache _distributedCache;
        #endregion

        #region Ctors
        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IDistributedCache distributedCache)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _distributedCache = distributedCache;
        }
        #endregion

        #region Methods
        public Task<ApiResult<bool>> AssignRole(Guid id, RoleAssignRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return new ApiErrorResult<string>("Tài khoản không tồn tại");
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Đăng nhập không đúng");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.GivenName, user.LastName),
                new Claim(ClaimTypes.Role, string.Join(';', roles)),
                new Claim(ClaimTypes.Name, request.UserName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigConstants.TokenWithKey));
            var creds = new SigningCredentials(key: key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(ConfigConstants.TokenIssuer,
                ConfigConstants.TokenIssuer, claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: creds);
            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại trong hệ thống. Vui lòng kiểm tra lại!");
            }
            IdentityResult response = await _userManager.DeleteAsync(user);
            if (!response.Succeeded)
            {
                return new ApiErrorResult<bool>("Có lỗi trong quá trình xóa tài khoản này. Vui lòng thử lại.");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<UserVm>> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                return new ApiErrorResult<UserVm>("Tài khoản không tòn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var res = new UserVm()
            {
                Id = id,
                UserName = user.UserName ?? "",
                Dob = user.Dob,
                Email = user.Email ?? "",
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber ?? "",
                Roles = roles
            };
            return new ApiSuccessResult<UserVm>(res);
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request)
        {
            ApiResult<PagedResult<UserVm>> response;
            var jsonDese = JsonConvert.SerializeObject(request);
            var keyCache = $"GetUsersPaging_{jsonDese}";
            byte[]? GetUsersPagingByArray;
            GetUsersPagingByArray = await _distributedCache.GetAsync(keyCache);
            if (GetUsersPagingByArray != null && GetUsersPagingByArray.Length > 0)
            {
                response = ConvertData<ApiResult<PagedResult<UserVm>>>.ByteArrayToObject(GetUsersPagingByArray);
                return response;
            }

            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query.Where(x => x.UserName.Contains(request.Keyword) || x.Email.Contains(request.Keyword));
            }
            int totalRow = query.Count();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new UserVm()
            {
                Email = x.Email ?? "",
                PhoneNumber = x.PhoneNumber ?? "",
                UserName = x.UserName ?? "",
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                Dob = x.Dob
            }).ToListAsync();
            var pageResult = new PagedResult<UserVm>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pageResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tải khoản đã tồn tại!");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại");
            }
            user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng ký không thành công");
        }

        public async Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại. Vui lòng kiểm tra lại");
            }
            bool isExistsUser = await _userManager.Users.AllAsync(x => x.Email == request.Email && x.Id != id);
            if (isExistsUser)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại trong hệ thống.");
            }
            user.Dob = request.Dob;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            IdentityResult response = await _userManager.UpdateAsync(user);
            if (!response.Succeeded)
            {
                return new ApiErrorResult<bool>("Có lỗi trong quá trình cập nhật tài khoản. Vui lòng thử lại.");
            }
            return new ApiSuccessResult<bool>("Cập nhật tài khoản thành công");
        }
        #endregion
    }
}
