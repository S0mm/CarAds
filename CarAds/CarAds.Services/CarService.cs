using System.Collections.Generic;
using System.Threading.Tasks;
using CarAds.Services.Contracts;
using CarAds.Services.Models;

namespace CarAds.Services
{
    public class CarService : ICarService
    {
        public Task<Car> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetByBrandAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetByBrandModelAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CreateAsync(Car car)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Car car)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}