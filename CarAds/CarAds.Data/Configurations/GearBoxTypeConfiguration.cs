using CarAds.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarAds.Data.Configurations
{
    public class GearBoxTypeConfiguration : IEntityTypeConfiguration<GearBoxTypeEntity>
    {
        public void Configure(EntityTypeBuilder<GearBoxTypeEntity> builder)
        {
            builder.ToTable("GearBoxType");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}