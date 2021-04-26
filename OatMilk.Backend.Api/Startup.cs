using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Controllers.Security;
using OatMilk.Backend.Api.Controllers.Security.Handlers;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.AutoMapper;

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
            services.AddAutoMapper(typeof(UserProfile));

            // Config
            services.Configure<ConnectionStringsOptions>(Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings));
            services.Configure<AuthOptions>(Configuration.GetSection(AuthOptions.Auth));

            // Context
            var connectionString = Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings).Get<ConnectionStringsOptions>().MainDatabase;
            services.AddDbContext<Context>(opt => opt.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            // HttpAccessor
            services.AddHttpContextAccessor();
            
            // Repositories
            services.AddScoped<IRepository<User>, UserRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();
            
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
            
            // Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JWTHelper.GetTokenValidationParameters(Configuration);
            });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireClaim(JWTClaimTypes.UserId)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            services.AddTransient<IAuthorizationHandler, UserAuthorizationHandler>();

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
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OatMilk.Backend.Api v1"));
            }

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
