using AutoMapper;
using CarAds.Api.Models.ActionModels;
using CarAds.Api.Models.ViewModels;
using CarAds.Services.Models;

namespace CarAds.Api.MappingProfiles
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            // ViewModels
            CreateMap<Car, CarViewModel>()
                .ForMember(dest => dest.ModelId,
                    opts => opts.MapFrom(src => src.BrandModel.Id))
                .ForMember(dest => dest.BrandId,
                    opts => opts.MapFrom(src => src.BrandModel.Brand.Id))
                .ReverseMap();

            // ActionModels
            CreateMap<Car, CarActionModel>()
                .ForMember(dest => dest.ModelId,
                    opts => opts.MapFrom(src => src.BrandModel.Id))
                .ForMember(dest => dest.BrandId,
                    opts => opts.MapFrom(src => src.BrandModel.Brand.Id))
                .ReverseMap();
        }
    }
}