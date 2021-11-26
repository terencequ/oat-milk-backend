using System.Threading.Tasks;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Users.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Users.Business.Models.Responses;

namespace OatMilk.Backend.Api.Modules.Users.Business.Abstractions
{
    public interface IUserService
    {
        /// <summary>
        /// Get user profile.
        /// </summary>
        /// <returns></returns>
        UserResponse GetUser(ObjectId userId);

        /// <summary>
        /// Login to a user account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Auth JWT to use for other endpoints.</returns>
        UserAuthTokenResponse Login(UserLoginRequest request);

        /// <summary>
        /// Register a new user account.
        /// Will login the user as well.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Auth JWT to use for other endpoints.</returns>
        Task<UserAuthTokenResponse> Register(UserRequest request);

        /// <summary>
        /// Check if a user of id <paramref name="userId"/> exists.
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>True if user exists, false otherwise.</returns>
        bool UserExistsById(ObjectId userId);
    }
}