using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
            var connectionString = configuration.GetConnectionString("MobileShopSolutionDb");

            var optionBuilder = new DbContextOptionsBuilder<MobileShopDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new MobileShopDbContext(optionBuilder.Options);
        }
    }
}
