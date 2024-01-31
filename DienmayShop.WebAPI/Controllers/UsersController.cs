using DienmayShop.Application.System.Users;
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
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authencate(loginRequest);
            if(resultToken == null)
            {
                return BadRequest(resultToken);
            }
            return Ok(resultToken);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]  RegisterRequest registerRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _userService.Register(registerRequest);
            if(!response.IsSuccessed)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }
        #endregion
    }
}
