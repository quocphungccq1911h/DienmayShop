using Microsoft.AspNetCore.Identity;

namespace DienmayShop.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; } = string.Empty;
    }
}
