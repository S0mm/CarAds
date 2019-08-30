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

            CreateMap<Car, CarEntity>()
                .ForMember(dest => dest.ConditionTypeId,
                           opts => opts.MapFrom(src => src.ConditionType.Id))
                .ForMember(dest => dest.FuelTypeId,
                           opts => opts.MapFrom(src => src.FuelType.Id))
                .ForMember(dest => dest.GearBoxTypeId,
                           opts => opts.MapFrom(src => src.GearBoxType.Id))
                .ForMember(dest => dest.CarBrandModelId,
                           opts => opts.MapFrom(src => src.BrandModel.Id))
                //.ForSourceMember(src => src.ConditionType, opts => opts.DoNotValidate())
                //.ForSourceMember(src => src.FuelType, opts => opts.DoNotValidate())
                //.ForSourceMember(src => src.GearBoxType, opts => opts.DoNotValidate())
                //.ForSourceMember(src => src.BrandModel, opts => opts.DoNotValidate())
                .ForMember(dest => dest.ConditionType, opt => opt.Ignore())
                .ForMember(dest => dest.FuelType, opt => opt.Ignore())
                .ForMember(dest => dest.GearBoxType, opt => opt.Ignore())
                .ForMember(dest => dest.CarBrandModel, opt => opt.Ignore())
            ;

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