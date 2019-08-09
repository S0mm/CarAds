using CarAds.Data;
using CarAds.DB.DataSeed;
using Microsoft.EntityFrameworkCore;

namespace CarAds.DB
{
    public class MigrationDbContext : CarAdsDbContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data
            modelBuilder.Seed();
        }
    }
}
