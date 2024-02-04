using DienmayShop.ViewModel.Common;

namespace DienmayShop.ViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public string LanguageId { get; set; } = "vi-VN";
        public int? CategoryId { get; set; }
    }
}
