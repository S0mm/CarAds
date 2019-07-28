using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarAds.Api.Models.ActionModels;
using CarAds.Api.Models.ViewModels;
using CarAds.Services.Contracts;
using CarAds.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAds.Api.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarService _carService;

        public CarController(IMapper mapper, ICarService carService)
        {
            _mapper = mapper;
            _carService = carService;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<CarViewModel> GetById(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            var model = _mapper.Map<CarViewModel>(car);
            return model;
        }

        [HttpGet]
        [Route("brand/{brandId}")]
        public async Task<IEnumerable<CarViewModel>> GetByBrand(int brandId)
        {
            var cars = await _carService.GetByBrandAsync(brandId);
            var model = _mapper.Map<IEnumerable<CarViewModel>>(cars);
            return model;
        }

        [HttpGet]
        [Route("model/{modelId}")]
        public async Task<IEnumerable<CarViewModel>> GetByModel(int modelId)
        {
            var cars = await _carService.GetByBrandModelAsync(modelId);
            var model = _mapper.Map<IEnumerable<CarViewModel>>(cars);
            return model;
        }

        [HttpPost]
        [Route("")]
        public async Task Create(CarActionModel model)
        {
            var car = _mapper.Map<Car>(model);
            var carId = await _carService.CreateAsync(car);
        }

        [HttpPut]
        [Route("")]
        public async Task Edit(CarActionModel model)
        {
            var car = _mapper.Map<Car>(model);
            await _carService.UpdateAsync(car);
        }

        [HttpDelete]
        [Route("")]
        public async Task Delete(int id)
        {
            await _carService.DeleteAsync(id);
        }
    }
}