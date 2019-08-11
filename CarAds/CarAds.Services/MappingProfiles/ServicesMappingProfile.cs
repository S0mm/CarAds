using AutoMapper;
using CarAds.Data.Entities;
using CarAds.Services.Models;

namespace CarAds.Services.MappingProfiles
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<CarEntity, Car>()
                .ForMember(dest => dest.BrandModel,
                    opts => opts.MapFrom(src => src.CarBrandModel));

            CreateMap<Brand, CarBrandEntity>().ReverseMap();

            CreateMap<BrandModel, CarBrandModelEntity>()
                .ForMember(dest => dest.CarBrand,
                    opts => opts.MapFrom(src => src.Brand))
                .ReverseMap();

            CreateMap<ConditionType, ConditionTypeEntity>().ReverseMap();

            CreateMap<FuelType, FuelTypeEntity>().ReverseMap();

            CreateMap<GearBoxType, GearBoxTypeEntity>().ReverseMap();

            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}