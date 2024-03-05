using DienmayShop.ViewModel.Catalog.Products;
using DienmayShop.ViewModel.Common;

namespace DienmayShop.Business.WebApiClient.Api.Interface
{
    public interface IProductApi
    {
        PagedResult<ProductVm> GetListLates(GetProductLatesRequest request);
    }
}
