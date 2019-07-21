using CarAds.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarAds.Data.Configurations
{
    public class CarBrandModelConfiguration : IEntityTypeConfiguration<CarBrandModelEntity>
    {
        public void Configure(EntityTypeBuilder<CarBrandModelEntity> builder)
        {
            builder.ToTable("CarBrandModel");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}