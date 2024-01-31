using DienmayShop.Configurations.Constants;
using DienmayShop.Data.Entities;
using DienmayShop.ViewModel.Common;
using DienmayShop.ViewModel.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
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
        #endregion

        #region Ctors
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            if(user == null)
            {
                return new ApiErrorResult<string>("Tài khoản không tồn tại");
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if(!result.Succeeded)
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

        public Task<ApiResult<bool>> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<UserVm>> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user is null)
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

        public Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if(user != null)
            {
                return new ApiErrorResult<bool>("Tải khoản đã tồn tại!");
            }
            if(await _userManager.FindByEmailAsync(request.Email) != null)
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
            if(result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng ký không thành công");
        }

        public Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
