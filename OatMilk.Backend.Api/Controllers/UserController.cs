using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using OatMilk.Backend.Api.Controllers.Security;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction.Interface;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Controllers
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
        [ProducesResponseType(typeof(AuthTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<AuthTokenResponse> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                return _userService.Login(request);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Register with new user credentials.
        /// </summary>
        /// <param name="request">New user credentials.</param>
        /// <returns>JWT Token.</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthTokenResponse>> Register([FromBody] UserRegisterRequest request)
        {
            try
            {
                return await _userService.Register(request);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Get this user's profile.
        /// </summary>
        /// <returns>User details.</returns>
        [AllowAnonymous]
        [HttpGet("profile")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<UserResponse> GetProfile()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                return _userService.GetUser(identity.GetUserIdOrDefault().GetValueOrDefault());
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Does this user exist?
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>True if exists, false if it doesn't.</returns>
        [AllowAnonymous]
        [HttpGet("exists")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<bool> UserExistsById([FromRoute] Guid userId)
        {
            try
            {
                return _userService.UserExistsById(userId);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
