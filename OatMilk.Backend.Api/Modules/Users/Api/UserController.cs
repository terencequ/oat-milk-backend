using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Modules.Core.Api.Models;
using OatMilk.Backend.Api.Modules.Core.Security;
using OatMilk.Backend.Api.Modules.Users.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Responses;

namespace OatMilk.Backend.Api.Modules.Users.Api
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Login with existing user credentials.
        /// </summary>
        /// <param name="request">Existing user credentials</param>
        /// <returns>JWT Token.</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(UserAuthTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<UserAuthTokenResponse> Login([FromBody] UserLoginRequest request)
        {
            return _userService.LoginAsync(request);
        }

        /// <summary>
        /// Register with new user credentials.
        /// </summary>
        /// <param name="request">New user credentials.</param>
        /// <returns>JWT Token.</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserAuthTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserAuthTokenResponse>> Register([FromBody] UserRequest request)
        {
            return await _userService.RegisterAsync(request);
        }

        /// <summary>
        /// Get this user's profile.
        /// </summary>
        /// <returns>User details.</returns>
        [AllowAnonymous]
        [HttpGet("profile")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<UserResponse> GetProfile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return _userService.GetByIdAsync(identity.GetUserIdOrDefault().GetValueOrDefault());
        }
    }
}
