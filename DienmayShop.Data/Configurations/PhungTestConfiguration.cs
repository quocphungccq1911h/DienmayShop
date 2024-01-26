using DienmayShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienmayShop.Data.Configurations
{
    public class PhungTestConfiguration : IEntityTypeConfiguration<PhungTest>
    {
        public void Configure(EntityTypeBuilder<PhungTest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().IsUnicode(false).HasMaxLength(5);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
        }
    }
}
