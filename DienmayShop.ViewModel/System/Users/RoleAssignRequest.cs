using DienmayShop.ViewModel.Common;

namespace DienmayShop.ViewModel.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SeletedItem> Roles { get; set; } = new List<SeletedItem>();
    }
}
