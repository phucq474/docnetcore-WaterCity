﻿using Invedia.DI;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Core.Configs;
using WaterCity.Repository.Infrastructure;
using WaterCity.WebApi.Extensions;
using ILogger = Serilog.ILogger;

namespace WaterCity.WebApi
{
    public class Startup
    {
        private IConfiguration _configuration;
        ILogger _logger;

        public Startup(WebApplicationBuilder builder, IWebHostEnvironment env)
        {
            _configuration = builder.Configuration;
            _logger = Log.Logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSystemSetting(_configuration.GetSection("SystemSetting").Get<SystemSettingModel>());

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "WaterCity", Version = "v1" });
            });

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = false;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = false;
            });
            services.AddAutoMapperServices();
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDI();
            services.PrintServiceAddedToConsole();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*var isUserSwagger = _configuration.GetValue<bool>("UseSwagger", false);
            if (isUserSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WaterCity v1");
                });
            }*/

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WaterCity v1");
            });

            app.UseAuthorization();
            app.UseSerilogRequestLogging();
            app.MapControllers();
            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
