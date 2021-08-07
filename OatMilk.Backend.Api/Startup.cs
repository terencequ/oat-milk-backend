using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OatMilk.Backend.Api.AspNet;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules;
using OatMilk.Backend.Api.Modules.Characters.Business;
using OatMilk.Backend.Api.Modules.Characters.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;
using OatMilk.Backend.Api.Modules.Users.Business;
using OatMilk.Backend.Api.Modules.Users.Business.Abstractions;

namespace OatMilk.Backend.Api
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
            // Config
            services.Configure<DatabaseOptions>(Configuration.GetSection(DatabaseOptions.Database));
            services.Configure<AuthOptions>(Configuration.GetSection(AuthOptions.Auth));

            // HttpAccessor
            services.AddHttpContextAccessor();

            // Register all business logic
            services.RegisterServices(Configuration);

            // CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowCredentials()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
 
            // Security
            services.ConfigureSecurity(Configuration);

            // Controllers
            services.AddControllers();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OatMilk.Backend.Api", Version = "v1" });
                
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OatMilk.Backend.Api v1");
                });
            }
            
            app.UseExceptionHandler("/error");

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
