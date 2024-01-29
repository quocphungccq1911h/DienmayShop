using DienmayShop.Application.PhungTest;
using DienmayShop.Data.SystemHelpers.RabbitMQ;
using DienmayShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DienmayShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhungTestsController : ControllerBase
    {
        private readonly IPhungTestService _phungTestService;
        private readonly IRabitMQProducer _rabitMQProducer;
        public PhungTestsController(IPhungTestService phungTestService, IRabitMQProducer rabitMQProducer)
        {
            _phungTestService = phungTestService;
            _rabitMQProducer = rabitMQProducer;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _phungTestService.GetAll();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PhungTestVM resquest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _phungTestService.Create(resquest);
            _rabitMQProducer.SendProductMessage(res);
            if (res > 0)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
    }
}
