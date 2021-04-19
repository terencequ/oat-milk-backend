using AutoMapper;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Models.Requests;
using OatMilk.Backend.Api.Data.Models.Responses;
using System;
using System.Linq;
using OatMilk.Backend.Api.Security;
using Microsoft.Extensions.Configuration;
using OatMilk.Backend.Api.Data.Models.Entities;

namespace OatMilk.Backend.Api.Repositories
{
    public interface IUserRepository
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
        AuthTokenResponse Register(UserRegisterRequest request);

        /// <summary>
        /// Check if a user of id <paramref name="userId"/> exists.
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <returns>True if user exists, false otherwise.</returns>
        bool UserExistsById(Guid userId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        private readonly IMapper _mapper;

        public UserRepository(IConfiguration configuration, Context context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        public UserResponse GetUser(Guid userId)
        {
            var user = _context.User.FirstOrDefault(u => userId == u.Id);
            if (user == null) // Email check
            {
                throw new ArgumentException("User could not be found.", nameof(userId));
            }
            
            return _mapper.Map<User, UserResponse>(user); 
        }

        public AuthTokenResponse Login(UserLoginRequest request)
        {
            var user = _context.User.FirstOrDefault(u => String.Equals(request.Email, u.Email, StringComparison.CurrentCultureIgnoreCase));
            
            if(user == null) // Email check
            {
                throw new ArgumentException("User could not be found.", nameof(request.Email));
            }

            if (!SecurePasswordHasher.Verify(request.Password, user.Password)) // Password check
            {
                throw new ArgumentException("User password is incorrect.", nameof(request.Password));
            }

            // Create token for user
            return new AuthTokenResponse()
            {
                AuthToken = JWTHelper.GenerateToken(_configuration, user.Id)
            };
        }

        public AuthTokenResponse Register(UserRegisterRequest request)
        {
            if(_context.User.Any(u => string.Equals(request.Email, u.Email, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new ArgumentException("User already exists.", nameof(request.Email));
            }

            // Create user
            var user = _mapper.Map<UserRegisterRequest, User>(request);
            user.Email = user.Email.ToLower();
            user.Password = SecurePasswordHasher.Hash(user.Password);
            user.CreatedUtc = DateTime.UtcNow;

            // Add user to database
            _context.Add(user);
            _context.SaveChanges();

            // Create token for user
            return new AuthTokenResponse()
            {
                AuthToken = JWTHelper.GenerateToken(_configuration, user.Id)
            };
        }

        public bool UserExistsById(Guid userId)
        {
            return _context.User.Any(user => user.Id == userId);
        }
    }
}
