using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarAds.Api.ActionModels;
using CarAds.Api.ViewModels;
using CarAds.Services.Contracts;
using CarAds.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAds.Api.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("{carId}")]
        public async Task<CarViewModel> GetById(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("brand/{brandId}")]
        public async Task<IEnumerable<CarViewModel>> GetByBrand(int brandId)
        {
            var cars = await _carService.GetByBrandAsync(brandId);
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("model/{modelId}")]
        public async Task<IEnumerable<CarViewModel>> GetByModel(int modelId)
        {
            var cars = await _carService.GetByBrandModelAsync(modelId);
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        public async Task Add(CarActionModel model)
        {
            var car = new Car();
            var carId = await _carService.CreateAsync(car);
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("")]
        public async Task Edit(CarActionModel model)
        {
            var car = new Car();
            await _carService.UpdateAsync(car);
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("")]
        public async Task Delete(int id)
        {
            await _carService.DeleteAsync(id);
            throw new NotImplementedException();
        }
    }
}