using AutoMapper;
using CarAds.Api.Models.ActionModels;
using CarAds.Api.Models.ViewModels;
using CarAds.Services.Models;

namespace CarAds.Api.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //// ViewModels
            //CreateMap<Car, CarViewModel>().ReverseMap();

            //// ActionModels
            //CreateMap<Car, CarActionModel>().ReverseMap();
        }
    }
}