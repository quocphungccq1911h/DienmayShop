using DienmayShop.Data.EF;
using DienmayShop.ViewModel.Catalog.Products;
using DienmayShop.ViewModel.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DienmayShop.Application.ClientCatalog.Product
{
    public class ProductClientService : IProductClientService
    {
        private readonly DienmayShopDbContext _context;
        public ProductClientService(DienmayShopDbContext context)
        {
            _context = context;
        }
        
        public async Task<PagedResult<ProductVm>> GetListLates(GetProductLatesRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        where pt.LanguageId == request.LanguageId && p.IsFeature == true
                        select new { p, pt, pic, c };
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize).Select(x => new ProductVm
            {
                Id = x.p.Id,
                Price = x.p.Price,
                OriginalPrice = x.p.OriginalPrice,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount,
                DateCreated = x.p.CreateDate,
                Name = x.pt.Name,
                Description = x.pt.Description,
                Details = x.pt.Details,
                SeoDescription = x.pt.SeoDescription,
                SeoTitle = x.pt.SeoTitle,
                SeoAlias = x.pt.SeoAlias,
                LanguageId = x.pt.LanguageId,
                IsFeatured = x.p.IsFeature,
                Categories = x.c.CategoryTranslations.Select(e => e.Name).ToList(),
            }).ToListAsync();
            // Select and Projection
            var pageResult = new PagedResult<ProductVm>
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pageResult;
        }
    }
}
