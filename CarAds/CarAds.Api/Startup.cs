using AutoMapper;
using CarAds.Api.Extensions.AutoMapper;
using CarAds.Api.MappingProfiles;
using CarAds.Data;
using CarAds.Data.Contracts;
using CarAds.Data.UnitOfWork;
using CarAds.Services;
using CarAds.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarAds.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarAdsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CarAds")));

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUnitOfWork, CarAdsUnitOfWork>();
            
            services.AddMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}