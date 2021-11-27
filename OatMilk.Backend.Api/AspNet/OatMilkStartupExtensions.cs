using System;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules;
using OatMilk.Backend.Api.Modules.Core.Security;
using OatMilk.Backend.Api.Modules.Core.Security.Handlers;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.AspNet
{
    public static class OatMilkStartupExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserEntityRepository<>), typeof(UserEntityRepository<>));

            var databaseOptions = configuration.GetSection(DatabaseOptions.Database).Get<DatabaseOptions>();
            var client = new MongoClient(databaseOptions.ConnectionString);
            var database = client.GetDatabase(databaseOptions.Name);

            // Module registration
            var oatMilkModule = new OatMilkModule(services, database);
            oatMilkModule.Register();
            
            return services;
        }

        public static IServiceCollection ConfigureSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            // Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JWTHelper.GetTokenValidationParameters(configuration);
            });
            services.AddSingleton<IAuthorizationHandler, UserAuthorizationHandler>();
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireClaim(JWTClaimTypes.UserId) 
                    .RequireAuthenticatedUser()
                    .Build();
            });
            return services;
        }
    }
}