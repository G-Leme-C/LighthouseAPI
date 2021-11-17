using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LighthouseAPI.MapProfiles;
using LighthouseData.ConfigurationModel;
using LighthouseData.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using AutoMapper;
using LighthouseDomain.Validators;
using LighthouseData.Model;
using FluentValidation;

namespace LighthouseAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LighthouseAPI", Version = "v1" });
            });


            services.Configure<LighthouseDatabaseSettings>(
                Configuration.GetSection(nameof(LighthouseDatabaseSettings))
            );

            services.AddSingleton<ILighthouseDatabaseSettings>(
                lighthouseDbSettings => 
                    lighthouseDbSettings.GetRequiredService<IOptions<LighthouseDatabaseSettings>>().Value
            );

            services.AddScoped<HelpReportRepository>();

            services.AddAutoMapper(typeof(LighthouseHelpReportProfile));

            services.AddScoped<IValidator<LighthouseHelpReport>, HelpReportValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LighthouseAPI v1"));
            }

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
