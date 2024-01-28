using DienmayShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DienmayShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhungTest>().HasData(
                new PhungTest
                {
                    Id = 1,
                    Name = "test thoi ma."
                }
           );
            #region AppUser
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "quocphungccq1911h@gmail.com",
                NormalizedEmail = "quocphungccq1911h@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "QuocPhung1994@"),
                SecurityStamp = string.Empty,
                FirstName = "Phung",
                LastName = "Phan",
                Dob = new DateTime(1994, 06, 11)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            #endregion
        }
    }
}
