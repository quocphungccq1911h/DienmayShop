using Microsoft.AspNetCore.Http;

namespace DienmayShop.ViewModel.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        public string Details { set; get; } = string.Empty;
        public string SeoDescription { set; get; } = string.Empty;
        public string SeoTitle { set; get; } = string.Empty;
        public string SeoAlias { get; set; } = string.Empty;
        public string LanguageId { set; get; } = "vi-VN";
        public bool? IsFeatured { get; set; }
        public IFormFile Thumbnail { get; set; }

    }
}
