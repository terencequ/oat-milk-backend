using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OatMilk.Backend.Api.Controllers.Security;
using OatMilk.Backend.Api.Controllers.Security.Handlers;

namespace OatMilk.Backend.Api.Shared.AspNet
{
    public static class StartupExtensions
    {
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