using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ModernMilkman.CustomerManagement.API.Attributes;
using ModernMilkman.CustomerManagement.API.Model;
using ModernMilkman.CustomerManagement.API.Services;
using ModernMilkman.CustomerManagement.API.Validation;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API
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

            services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ModernMilkman.CustomerManagement.API", Version = "v1" });

                c.OperationFilter<MyHeaderFilter>();
            });

            services.AddSingleton<IDataRepository, DataRepository>();

            services.AddApiVersioning(version =>
                {
                    version.DefaultApiVersion = new ApiVersion(1, 0);
                    version.AssumeDefaultVersionWhenUnspecified = true;
                    version.ReportApiVersions = true;
                }
            );

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            services.AddScoped<Serilog.ILogger>(l => { return logger; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ModernMilkman.CustomerManagement.API v1"));
            }
            else
            {
                app.UseExceptionHandler("/error");
            }    

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSerilogRequestLogging();
        }
    }
}
