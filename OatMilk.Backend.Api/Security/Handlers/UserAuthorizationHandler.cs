using Microsoft.AspNetCore.Authorization;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Security.Requirements;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Security.Handlers
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
            bool ValidUserIdPredicate(Claim c)
            {
                return c.Type == JWTClaimTypes.UserId && _userService.UserExistsById(Guid.Parse(c.Value));
            }

            if (context.User.HasClaim(ValidUserIdPredicate))
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
