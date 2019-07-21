using CarAds.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarAds.Data.Configurations
{
    public class CarBrandConfiguration : IEntityTypeConfiguration<CarBrandEntity>
    {
        public void Configure(EntityTypeBuilder<CarBrandEntity> builder)
        {
            builder.ToTable("CarBrand");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}