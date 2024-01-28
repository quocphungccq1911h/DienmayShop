using Microsoft.AspNetCore.Identity;

namespace DienmayShop.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
    }
}
