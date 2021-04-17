using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OatMilk.Backend.Api.Controllers.Helpers;
using OatMilk.Backend.Api.Data.Models.Requests;
using OatMilk.Backend.Api.Data.Models.Responses;
using OatMilk.Backend.Api.Repositories;
using OatMilk.Backend.Api.Security;
using System;
using System.Security.Claims;

namespace OatMilk.Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Login with existing user credentials.
        /// </summary>
        /// <param name="request">Existing user credentials</param>
        /// <returns>JWT Token.</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthTokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ArgumentErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<AuthTokenResponse> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                return _userRepository.Login(request);
            } catch (ArgumentException exception)
            {
                return ExceptionHelper.ConvertExceptionToResult(exception);
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
        [ProducesResponseType(typeof(ArgumentErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<AuthTokenResponse> Register([FromBody] UserRegisterRequest request)
        {
            try
            {
                return _userRepository.Register(request);
            }
            catch (Exception exception)
            {
                return ExceptionHelper.ConvertExceptionToResult(exception);
            }
        }

        /// <summary>
        /// Get this user's profile.
        /// </summary>
        /// <returns>User details.</returns>
        [AllowAnonymous]
        [HttpGet("profile")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ArgumentErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<UserResponse> GetProfile()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                return _userRepository.GetUser(identity.GetUserId());
            }
            catch (Exception exception)
            {
                return ExceptionHelper.ConvertExceptionToResult(exception);
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
        [ProducesResponseType(typeof(ArgumentErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<bool> UserExistsById([FromRoute] Guid userId)
        {
            try
            {
                return _userRepository.UserExistsById(userId);
            }
            catch (Exception exception)
            {
                return ExceptionHelper.ConvertExceptionToResult(exception);
            }
        }
    }
}
