using DienmayShop.Data.Configurations;
using DienmayShop.Data.Entities;
using DienmayShop.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DienmayShop.Data.EF
{
    public class DienmayShopDbContext : DbContext
    {
        public DienmayShopDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Config use Fluent API
            modelBuilder.ApplyConfiguration(new PhungTestConfiguration());
            modelBuilder.Seed();
        }

        public DbSet<PhungTest> PhungTests { get; set; }
    }
}
