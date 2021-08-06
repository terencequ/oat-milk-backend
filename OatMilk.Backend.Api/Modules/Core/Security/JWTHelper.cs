using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using OatMilk.Backend.Api.Configuration;

namespace OatMilk.Backend.Api.Modules.Core.Security
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
        public static string GenerateToken(IConfiguration configuration, ObjectId userId)
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
        public static ObjectId? GetUserIdOrDefault(this ClaimsIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity), $"Argument is null. ({nameof(identity)})");
            }
            
            if(ObjectId.TryParse(identity.FindFirst(JWTClaimTypes.UserId)?.Value, out var userId))
            {
                return userId;
            }
            return null;
        }
    }
}
