using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Controllers.Security;
using OatMilk.Backend.Api.Controllers.Security.Handlers;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.AutoMapper;
using OatMilk.Backend.Api.Shared.AspNet;
using OatMilk.Backend.Api.Shared.Repositories.Abstraction;
using OatMilk.Backend.Api.Shared.Services.Abstractions;

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
            // AutoMapper
            services.AddAutoMapper(AutoMapperHelper.GetAutoMapperTypes());

            // Config
            services.Configure<DatabaseOptions>(Configuration.GetSection(DatabaseOptions.Database));
            services.Configure<AuthOptions>(Configuration.GetSection(AuthOptions.Auth));

            // HttpAccessor
            services.AddHttpContextAccessor();
            
            // MongoDB database
            services.SetupDatabase(Configuration);
            
            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserEntityRepository<>), typeof(UserEntityRepository<>));

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICharacterService, CharacterService>();

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
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OatMilk.Backend.Api v1"));
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
