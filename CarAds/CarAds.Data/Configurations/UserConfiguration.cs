using CarAds.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarAds.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.SecondName).HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(30);
        }
    }
}