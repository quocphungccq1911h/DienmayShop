using DienmayShop.Application.PhungTest;
using Microsoft.AspNetCore.Mvc;

namespace DienmayShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhungTestsController : ControllerBase
    {
        private readonly IPhungTestService _phungTestService;
        public PhungTestsController(IPhungTestService phungTestService)
        {
            _phungTestService = phungTestService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _phungTestService.GetAll();
            return Ok(data);
        }
    }
}
