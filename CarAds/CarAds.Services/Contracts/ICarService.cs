using System.Collections.Generic;
using System.Threading.Tasks;
using CarAds.Services.Models;

namespace CarAds.Services.Contracts
{
    public interface ICarService
    {
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> GetByBrandAsync(int id);
        Task<IEnumerable<Car>> GetByBrandModelAsync(int id);
        Task<int> CreateAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(int id);
    }
}