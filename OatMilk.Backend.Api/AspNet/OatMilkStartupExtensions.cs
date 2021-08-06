using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules;
using OatMilk.Backend.Api.Modules.Core.Security;
using OatMilk.Backend.Api.Modules.Core.Security.Handlers;

namespace OatMilk.Backend.Api.AspNet
{
    public static partial class OatMilkStartupExtensions
    {
        
        
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseOptions = configuration.GetSection(DatabaseOptions.Database).Get<DatabaseOptions>();
            var client = new MongoClient(databaseOptions.ConnectionString);
            var database = client.GetDatabase(databaseOptions.Name);

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
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireClaim(JWTClaimTypes.UserId)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            services.AddTransient<IAuthorizationHandler, UserAuthorizationHandler>();
            return services;
        }
    }
}