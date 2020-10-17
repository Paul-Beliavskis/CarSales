using System.Reflection;
using AutoMapper;
using CarSales.VehicleManagement.API.Constants;
using CarSales.VehicleManagement.API.DTO;
using CarSales.VehicleManagement.API.Extensions;
using CarSales.VehicleManagement.API.HandlerRequests;
using CarSales.VehicleManagement.DATA;
using CarSales.VehicleManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CarSales.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarSales.API", Version = "v1" });
            });

            services.AddAutoMapper(config =>
            {
                config.CreateMap<PutVehicleRequest, Car>();
                config.CreateMap<Car, CarDTO>();
                config.CreateMap<DeleteVehicleRequest, Vehicle>().ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.VehicleId));

            });

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<CarSalesDbContext>(options =>
            {
                options.UseInMemoryDatabase(Configuration[ConfigurationConstants.SQLDatabaseNameConfig]);
            }, ServiceLifetime.Singleton);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarSales.API v1"));
            }

            //Handles all exceptions for the application
            app.UseExceptionHandling();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
