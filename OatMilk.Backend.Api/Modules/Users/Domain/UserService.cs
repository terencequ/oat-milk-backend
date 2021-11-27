using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Core.Security;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;
using OatMilk.Backend.Api.Modules.Users.Data;
using OatMilk.Backend.Api.Modules.Users.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Responses;

namespace OatMilk.Backend.Api.Modules.Users.Domain
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration, IRepository<User> repository, IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
        }

        public Task<UserResponse> GetByIdAsync(ObjectId userId)
        {
            var user = _repository.Get().FirstOrDefault(u => userId == u.Id);
            if (user == null) // Email check
            {
                throw new ArgumentException("User could not be found.", nameof(userId));
            }

            var result = _mapper.Map<User, UserResponse>(user);
            return Task.FromResult(result); 
        }

        public Task<UserAuthTokenResponse> LoginAsync(UserLoginRequest request)
        {
            var user = _repository.Get().FirstOrDefault(u => request.Email.ToLower() == u.Email.ToLower());
            
            if(user == null) // Email check
            {
                throw new ArgumentException("User could not be found.", nameof(request.Email));
            }

            if (!SecurePasswordHasher.Verify(request.Password, user.Password)) // Password check
            {
                throw new ArgumentException("User password is incorrect.", nameof(request.Password));
            }

            // Create token for user
            var result = new UserAuthTokenResponse()
            {
                AuthToken = JWTHelper.GenerateToken(_configuration, user.Id)
            };
            return Task.FromResult(result);
        }

        public async Task<UserAuthTokenResponse> RegisterAsync(UserRequest request)
        {
            if(_repository.Get().Any(u => request.Email.ToLower() == u.Email.ToLower()))
            {
                throw new ArgumentException("User already exists.", nameof(request.Email));
            }

            // Create user
            var user = _mapper.Map<UserRequest, User>(request);
            user.Email = user.Email.ToLower();
            user.Password = SecurePasswordHasher.Hash(user.Password);
            user.CreatedDateTimeUtc = DateTime.UtcNow;
            user.UpdatedDateTimeUtc = DateTime.UtcNow;

            // Add user to database
            await _repository.AddAsync(user);

            // Create token for user
            return new UserAuthTokenResponse()
            {
                AuthToken = JWTHelper.GenerateToken(_configuration, user.Id)
            };
        }

        public Task<bool> UserExistsByIdAsync(ObjectId userId)
        {
            return 6_repository.Get().Any(user => user.Id == userId);
        }
    }
}
