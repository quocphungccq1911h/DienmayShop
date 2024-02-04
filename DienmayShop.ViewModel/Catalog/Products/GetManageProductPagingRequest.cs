using DienmayShop.ViewModel.Common;

namespace DienmayShop.ViewModel.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; } = string.Empty;
        public string LanguageId { get; set; } = "vi-VN";
        public List<int>? CategoryIds { get; set; }
        public int? CategoryId { get; set; }
    }
}
