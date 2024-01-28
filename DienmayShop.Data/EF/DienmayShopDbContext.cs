using DienmayShop.Data.Configurations;
using DienmayShop.Data.Entities;
using DienmayShop.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DienmayShop.Data.EF
{
    public class DienmayShopDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DienmayShopDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Config use Fluent API
            builder.ApplyConfiguration(new PhungTestConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new AppRoleConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CategoryTranslationConfiguration());

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaim");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            builder.Seed();
        }

        public DbSet<PhungTest> PhungTests { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<CategoryTranslation> CategoryTranslations { set; get; }
    }
}
