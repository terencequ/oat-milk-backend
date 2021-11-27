using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Core.Security.Requirements;
using OatMilk.Backend.Api.Modules.Users.Domain.Abstractions;

namespace OatMilk.Backend.Api.Modules.Core.Security.Handlers
{
    public class UserAuthorizationHandler : AuthorizationHandler<UserAuthorizationRequirement>
    {
        private IUserService _userService;

        public UserAuthorizationHandler(IUserService userService)
        {
            _userService = userService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAuthorizationRequirement requirement)
        {
            bool ValidUserIdPredicateAsync(Claim c)
            {
                return c.Type == JWTClaimTypes.UserId && _userService.ExistsByIdAsync(ObjectId.Parse(c.Value)).Result;
            }

            if (context.User.HasClaim(ValidUserIdPredicateAsync))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            
            return Task.CompletedTask;
        }
    }
}
