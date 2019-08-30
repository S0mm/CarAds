using System.Collections.Generic;
using System.Linq;
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
            var carEntity = await _unitOfWork.GetRepository<CarEntity>().GetByIdAsync(id);
            var car = _mapper.Map<Car>(carEntity);

            return car;
        }

        public async Task<IEnumerable<Car>> GetByBrandAsync(int id)
        {
            var carEntities = await _unitOfWork.GetRepository<CarEntity>()
                .GetAsync(car => car.CarBrandModel.CarBrandId == id);

            var cars = _mapper.Map<IEnumerable<Car>>(carEntities);

            return cars;
        }

        public async Task<IEnumerable<Car>> GetByBrandModelAsync(int id)
        {
            var carEntities = await _unitOfWork.GetRepository<CarEntity>()
                .GetAsync(car => car.CarBrandModelId == id);

            var cars = _mapper.Map<IEnumerable<Car>>(carEntities);

            return cars;
        }

        public async Task<int> CreateAsync(Car car)
        {
            var carEntity = _mapper.Map<CarEntity>(car);

            _unitOfWork.GetRepository<CarEntity>().Add(carEntity);

            await _unitOfWork.SaveChangesAsync();

            return carEntity.Id;
        }

        public async Task UpdateAsync(Car car)
        {
            var carEntity = _mapper.Map<CarEntity>(car);

            _unitOfWork.GetRepository<CarEntity>().Update(carEntity);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.GetRepository<CarEntity>().Delete(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> CarExistsAsync(int id)
        {
            var carEntity = await _unitOfWork.GetRepository<CarEntity>().GetByIdAsync(id);

            return carEntity != null;
        }
    }
}