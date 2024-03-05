using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DienmayShop.WebApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        public HomesController() { }

        [HttpGet]
        public async Task<IActionResult> GetHomeData()
        {

        }
    }
}
