using AutoMapper;

using Adres.API.Services;

using Adres.API.Services.Interfaces;
using Adres.API.Services.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Adres.API.Data.Contracts.Interfaces;
using Adres.API.Data;
using Adres.API.Data.Repositories;
using Newtonsoft.Json.Serialization;


namespace Adres.API
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
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    options.SerializerSettings.ContractResolver= new CamelCasePropertyNamesContractResolver();
                });
            var connectionStrings = Configuration.GetConnectionString("AdresDbContext");          

            services
                .AddDbContext<AdresContext>(options => options
                    .UseSqlite(connectionStrings, builder =>
                        builder.MigrationsHistoryTable("__EFMigrationsHistory")
              ));


            services
                .AddCors(options => options
                    .AddPolicy("AllowOrigin", builder => builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(host => true)
                        .AllowCredentials()));

            AddSwagger(services);
            //AddHangfire(services);
            AddAutoMapper(services);
            DependencyInjection(services);
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services
                .AddSwaggerGen(options =>
                {
                    var groupName = "v1";
                    options.CustomSchemaIds(type => type.ToString());
                    options.SwaggerDoc(groupName, new OpenApiInfo
                    {
                        Title = $"Adres.API {groupName}",
                        Version = groupName,
                        Description = "Adres API",
                        Contact = new OpenApiContact
                        {
                            Name = "LocalPayment",
                            Email = string.Empty,
                            Url = new Uri("https://www.Adres.com/"),
                        }
                    });
                })
                .AddSwaggerGenNewtonsoftSupport();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            });
            services.AddSingleton(config.CreateMapper());
        }

        private void DependencyInjection(IServiceCollection services)
        {
            // Configs
            //   services.Configure<LPSettings>(Configuration.GetSection(nameof(LPSettings)));



            // Repos
            services.AddScoped<IAcquisitionRequirementRepository, AcquisitionRequirementRepository>();

            // Services
            services.AddScoped<IAcquisitionRequirementService, AcquisitionRequirementService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandling();

            app.UseCors("AllowOrigin");

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<AdresContext>();
                context.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRequestPerformanceLogging();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

        }
    }
}