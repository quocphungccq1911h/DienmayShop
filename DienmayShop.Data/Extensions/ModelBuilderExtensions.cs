using DienmayShop.Data.Entities;
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
        }
    }
}
