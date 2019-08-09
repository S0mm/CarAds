using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarAds.Data.Contracts;
using CarAds.Data.Entities;
using CarAds.Services.Contracts;
using CarAds.Services.Models;

namespace CarAds.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CarService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            var carEntity = await _unitOfWork.GetRepository<CarEntity>()
                .GetByIdAsync(id)
                .ConfigureAwait(false);

            var car = _mapper.Map<Car>(carEntity);

            return car;
        }

        public async Task<IEnumerable<Car>> GetByBrandAsync(int id)
        {
            var carEntities = await _unitOfWork.GetRepository<CarEntity>()
                .GetAsync(car => car.Id == id)
                .ConfigureAwait(false);

            var cars = _mapper.Map<IEnumerable<Car>>(carEntities);

            return cars;
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