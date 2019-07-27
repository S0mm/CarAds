using CarAds.Data;
using Microsoft.EntityFrameworkCore;

namespace CarAds.DB
{
    public class MigrationContext : CarAdsContext
    {
        public MigrationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
