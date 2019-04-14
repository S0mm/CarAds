using CarAds.Data.Configurations;
using CarAds.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarAds.Data
{
    public class CarAdsContext : DbContext
    {
        public CarAdsContext(DbContextOptions<CarAdsContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new ConditionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FuelTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GearBoxTypeConfiguration());
        }
        
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<ConditionTypeEntity> ConditionTypes { get; set; }
        public DbSet<FuelTypeEntity> FuelTypes { get; set; }
        public DbSet<GearBoxTypeEntity> GearBoxTypes { get; set; }
    }
}