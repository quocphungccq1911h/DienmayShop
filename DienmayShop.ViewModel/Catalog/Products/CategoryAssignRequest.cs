using DienmayShop.ViewModel.Common;

namespace DienmayShop.ViewModel.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SeletedItem> Categories { get; set; } = new List<SeletedItem>();
    }
}
