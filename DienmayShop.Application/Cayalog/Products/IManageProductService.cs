using DienmayShop.ViewModel.Catalog.Products;
using DienmayShop.ViewModel.Common;
using Microsoft.AspNetCore.Http;

namespace DienmayShop.Application.Cayalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<List<ProductVm>> GetAll();
        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<int> AddImages(int productId, List<IFormFile> files);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, string caption, bool isDefault);
        Task<List<ProductImageVM>> GetListImage(int productId);
        Task<ApiResult<ProductVm>> GetProductById(int productId, string languageId);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<ApiResult<List<ProductVm>>> GetListProductFeature(string languageId);
    }
}
