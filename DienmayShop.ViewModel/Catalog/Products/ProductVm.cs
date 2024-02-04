namespace DienmayShop.ViewModel.Catalog.Products
{
    public class ProductVm
    {
        public int Id { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        public string Details { set; get; } = string.Empty;
        public string SeoDescription { set; get; } = string.Empty;
        public string SeoTitle { set; get; } = string.Empty;
        public string SeoAlias { get; set; } = string.Empty;
        public string LanguageId { set; get; } = string.Empty;
        public bool? IsFeatured { get; set; }
        public string ThumbnailImage { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new List<string>();
    }
}
