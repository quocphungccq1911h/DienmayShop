using DienmayShop.ViewModel.Catalog.Products;
using DienmayShop.ViewModel.Common;

namespace DienmayShop.Business.WebApiClient.Services.Interface
{
    public interface IProductService
    {
        Task<PagedResult<ProductVm>> GetListLates(GetProductLatesRequest request);
    }
}
