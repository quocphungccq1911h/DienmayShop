using DienmayShop.ViewModel.Common;

namespace DienmayShop.ViewModel.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
