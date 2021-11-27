using System.Threading.Tasks;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Responses;

namespace OatMilk.Backend.Api.Modules.Users.Domain.Abstractions
{
    public interface IUserService
    {
        /// <summary>
        /// Get user profile.
        /// </summary>
        /// <returns></returns>
        Task<UserResponse> GetByIdAsync(ObjectId userId);

        /// <summary>
        /// Login to a user account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Auth JWT to use for other endpoints.</returns>
        Task<UserAuthTokenResponse> LoginAsync(UserLoginRequest request);

        /// <summary>
        /// Register a new user account.
        /// Will login the user as well.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Auth JWT to use for other endpoints.</returns>
        Task<UserAuthTokenResponse> RegisterAsync(UserRequest request);

        /// <summary>
        /// Check if a user of id <paramref name="userId"/> exists.
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>True if user exists, false otherwise.</returns>
        Task<bool> UserExistsByIdAsync(ObjectId userId);
    }
}