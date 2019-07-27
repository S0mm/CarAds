using CarAds.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarAds.DB.DataSeed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConditionTypeEntity>().HasData(
                new ConditionTypeEntity { Id = 1, Name = "new" },
                new ConditionTypeEntity { Id = 2, Name = "good condition" },
                new ConditionTypeEntity { Id = 3, Name = "require repair" },
                new ConditionTypeEntity { Id = 4, Name = "out of service" }
            );

            modelBuilder.Entity<FuelTypeEntity>().HasData(
                new FuelTypeEntity { Id = 1, Name = "petrol" },
                new FuelTypeEntity { Id = 2, Name = "diesel" },
                new FuelTypeEntity { Id = 3, Name = "electric" },
                new FuelTypeEntity { Id = 4, Name = "hybrid" },
                new FuelTypeEntity { Id = 5, Name = "LPG" },
                new FuelTypeEntity { Id = 6, Name = "natural gas" },
                new FuelTypeEntity { Id = 7, Name = "other" }
            );

            modelBuilder.Entity<GearBoxTypeEntity>().HasData(
                new GearBoxTypeEntity { Id = 1, Name = "manual gearbox" },
                new GearBoxTypeEntity { Id = 2, Name = "automatic transmission" }
            );

            modelBuilder.Entity<CarBrandEntity>().HasData(
                new CarBrandEntity { Id = 1, Name = "Audi" },
                new CarBrandEntity { Id = 2, Name = "BMW" },
                new CarBrandEntity { Id = 3, Name = "Toyota" },
                new CarBrandEntity { Id = 4, Name = "Volvo" }
            );

            modelBuilder.Entity<CarBrandModelEntity>().HasData(
                new CarBrandModelEntity { Id = 1, CarBrandId = 1, Name = "80" },
                new CarBrandModelEntity { Id = 2, CarBrandId = 1, Name = "100" },
                new CarBrandModelEntity { Id = 3, CarBrandId = 1, Name = "A4" },
                new CarBrandModelEntity { Id = 4, CarBrandId = 1, Name = "A6" },
                new CarBrandModelEntity { Id = 5, CarBrandId = 1, Name = "A8" },

                new CarBrandModelEntity { Id = 6, CarBrandId = 2, Name = "135" },
                new CarBrandModelEntity { Id = 7, CarBrandId = 2, Name = "230" },
                new CarBrandModelEntity { Id = 8, CarBrandId = 2, Name = "340" },
                new CarBrandModelEntity { Id = 9, CarBrandId = 2, Name = "440" },
                new CarBrandModelEntity { Id = 10, CarBrandId = 2, Name = "760" },

                new CarBrandModelEntity { Id = 11, CarBrandId = 3, Name = "Auris" },
                new CarBrandModelEntity { Id = 12, CarBrandId = 3, Name = "Camry" },
                new CarBrandModelEntity { Id = 13, CarBrandId = 3, Name = "Corolla" },
                new CarBrandModelEntity { Id = 14, CarBrandId = 3, Name = "Prius" },
                new CarBrandModelEntity { Id = 15, CarBrandId = 3, Name = "Picnic" },
                new CarBrandModelEntity { Id = 16, CarBrandId = 3, Name = "Yaris" },

                new CarBrandModelEntity { Id = 17, CarBrandId = 4, Name = "240" },
                new CarBrandModelEntity { Id = 18, CarBrandId = 4, Name = "440" },
                new CarBrandModelEntity { Id = 19, CarBrandId = 4, Name = "S40" },
                new CarBrandModelEntity { Id = 20, CarBrandId = 4, Name = "V60" },
                new CarBrandModelEntity { Id = 21, CarBrandId = 4, Name = "V60" },
                new CarBrandModelEntity { Id = 22, CarBrandId = 4, Name = "XC60" },
                new CarBrandModelEntity { Id = 23, CarBrandId = 4, Name = "XC70" },
                new CarBrandModelEntity { Id = 24, CarBrandId = 4, Name = "XC90" }
            );
        }
    }
}
