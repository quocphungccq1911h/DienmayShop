using DienmayShop.Business.WebApiClient.Services.Interface;
using DienmayShop.ViewModel.Catalog.Products;
using DienmayShop.ViewModel.Common;

namespace DienmayShop.Business.WebApiClient.Services
{
    public class ProductService : IProductService
    {
        public Task<PagedResult<ProductVm>> GetListLates(GetProductLatesRequest request)
        {
            var result = new PagedResult<ProductVm>();

        }
    }
}
