using DienmayShop.Application.Common;
using DienmayShop.Data.EF;
using DienmayShop.Utilities.Extensions;
using DienmayShop.ViewModel.Catalog.Products;
using DienmayShop.ViewModel.Common;
using Microsoft.AspNetCore.Http;

namespace DienmayShop.Application.Cayalog.Products
{
    public class ManageProductService : IManageProductService
    {
        #region Fields
        private readonly DienmayShopDbContext _context;
        private readonly IStorageService _storageService;
        #endregion

        #region Ctors
        public ManageProductService(DienmayShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        #endregion

        #region Methods
        public Task<int> AddImages(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product is not null) product.ViewCount++;
            await _context.SaveChangesAsync();
        }

        public Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(ProductCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product is null) throw new DienmayShopException($"Không thể tìm thấy sản phẩm với mã: {productId}");
            var images = _context.ProductImages.Where(x => x.ProductId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public Task<List<ProductVm>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageVM>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<List<ProductVm>>> GetListProductFeature(string languageId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<ProductVm>> GetProductById(int productId, string languageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
