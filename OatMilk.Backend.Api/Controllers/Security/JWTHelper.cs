using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OatMilk.Backend.Api.Configuration;

namespace OatMilk.Backend.Api.Controllers.Security
{
    public static class JWTHelper
    {
        /// <summary>
        /// Validation parameters to validate a token based on the secret in <paramref name="configuration"/>.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        {
            var secret = configuration
                .GetSection(AuthOptions.Auth)
                .Get<AuthOptions>()
                .UserTokenSecret;

            return new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret))
            };
        }

        /// <summary>
        /// Generate a token using the secret from <paramref name="configuration"/>.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GenerateToken(IConfiguration configuration, Guid userId)
        {
            var secret = configuration
                .GetSection(AuthOptions.Auth)
                .Get<AuthOptions>()
                .UserTokenSecret;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JWTClaimTypes.UserId, userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Get user ID from ClaimsIdentity.
        /// </summary>
        /// <param name="identity">ClaimsIdentity from a JWT.</param>
        /// <returns></returns>
        public static Guid GetUserId(this ClaimsIdentity identity)
        {
            if (identity != null)
            {
                if(Guid.TryParse(identity.FindFirst(JWTClaimTypes.UserId)?.Value, out var userId))
                {
                    return userId;
                } else {
                    throw new ArgumentException(nameof(identity), $"Identity is invalid, User Id is either null or cannot be parsed as Guid.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(identity), $"Argument is null. ({nameof(identity)})");
            }
        }
    }
}
