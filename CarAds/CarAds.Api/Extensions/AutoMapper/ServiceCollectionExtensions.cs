using AutoMapper;
using CarAds.Api.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace CarAds.Api.Extensions.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
