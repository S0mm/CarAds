using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CarAds.DB
{
    // The DesignTimeDbContextFactory class is needed because EF Core Migrations are launched from class library.
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MigrationContext>
    {
        public MigrationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MigrationContext>();

            var connectionString = configuration.GetConnectionString("CarAds");

            builder.UseSqlServer(connectionString);

            return new MigrationContext(builder.Options);
        }
    }
}
