using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OatMilk.Backend.Api.Controllers.Security.Requirements;
using OatMilk.Backend.Api.Services.Abstraction;

namespace OatMilk.Backend.Api.Controllers.Security.Handlers
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
