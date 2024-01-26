using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DienmayShop.Data.EF
{
    public class DienmayShopDbContextFactory : IDesignTimeDbContextFactory<DienmayShopDbContext>
    {
        public DienmayShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string? connectionString = configuration.GetConnectionString("DienmayShopDB");
            var optionBuilder = new DbContextOptionsBuilder<DienmayShopDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new DienmayShopDbContext(optionBuilder.Options);
        }
    }
}
