using Microsoft.AspNetCore.Authorization;
using OatMilk.Backend.Api.Repositories;
using OatMilk.Backend.Api.Security.Requirements;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Security.Handlers
{
    public class UserAuthorizationHandler : AuthorizationHandler<UserAuthorizationRequirement>
    {
        private IUserRepository _userRepository;

        public UserAuthorizationHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAuthorizationRequirement requirement)
        {
            bool ValidUserIdPredicate(Claim c)
            {
                return c.Type == JWTClaimTypes.UserId && _userRepository.UserExistsById(Guid.Parse(c.Value));
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
