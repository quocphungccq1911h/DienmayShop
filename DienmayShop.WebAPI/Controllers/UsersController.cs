using DienmayShop.Application.System.Users;
using DienmayShop.ViewModel.Common;
using DienmayShop.ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DienmayShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion

        #region Ctors
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Methods

        #region Authenticate
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authencate(loginRequest);
            if (resultToken == null)
            {
                return BadRequest(resultToken);
            }
            return Ok(resultToken);
        }
        #endregion

        #region Register
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _userService.Register(registerRequest);
            if (!response.IsSuccessed)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }
        #endregion

        #region DeleteUser
        [HttpDelete("DeleteUserWithId")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Tài khoản không hợp lệ. Vui lòng kiểm tra lại");
            }
            ApiResult<bool> response = await _userService.DeleteUser(id);
            return Ok(response);

        }
        #endregion

        #region UpdateUser
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateRequest request)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("Tài khoản không tồn tại. Vui lòng kiểm tra lại");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _userService.UpdateUser(id, request);
            if(!response.IsSuccessed)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Get List User Paging
        [HttpGet("GetUserPaging")]
        public async Task<IActionResult> GetUserPaging([FromQuery] GetUserPagingRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _userService.GetUsersPaging(request);
            if(!response.IsSuccessed)
            {
                return BadRequest(response);
            }
            return Ok(response);    
        }
        #endregion

        #endregion
    }
}
