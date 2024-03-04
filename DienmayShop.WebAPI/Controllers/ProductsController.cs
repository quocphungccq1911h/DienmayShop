using DienmayShop.Application.Catalog.Products;
using DienmayShop.ViewModel.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DienmayShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields
        private readonly IManageProductService _productService;
        #endregion

        #region Ctor
        public ProductsController(IManageProductService productService)
        {
            _productService = productService;
        }
        #endregion
        [HttpPost("GetListProductLates")]
        public async Task<IActionResult> GetProductLatest([FromBody]GetProductLatesRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _productService.GetListLates(request);
            if (response == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(response);
        }
    }
}
