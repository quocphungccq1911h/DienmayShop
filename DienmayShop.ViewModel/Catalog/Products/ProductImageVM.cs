namespace DienmayShop.ViewModel.Catalog.Products
{
    public class ProductImageVM
    {
        public int Id { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public long FileSize { get; set; }
    }
}
