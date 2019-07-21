using CarAds.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarAds.Data.Configurations
{
    public class ConditionTypeConfiguration : IEntityTypeConfiguration<ConditionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ConditionTypeEntity> builder)
        {
            builder.ToTable("FuelType");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}