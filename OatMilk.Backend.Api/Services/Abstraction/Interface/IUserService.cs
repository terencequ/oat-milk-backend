using System;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.Abstraction.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Get user profile.
        /// </summary>
        /// <returns></returns>
        UserResponse GetUser(Guid userId);

        /// <summary>
        /// Login to a user account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Auth JWT to use for other endpoints.</returns>
        AuthTokenResponse Login(UserLoginRequest request);

        /// <summary>
        /// Register a new user account.
        /// Will login the user as well.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Auth JWT to use for other endpoints.</returns>
        Task<AuthTokenResponse> Register(UserRegisterRequest request);

        /// <summary>
        /// Check if a user of id <paramref name="userId"/> exists.
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>True if user exists, false otherwise.</returns>
        bool UserExistsById(Guid userId);
    }
}