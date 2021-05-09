using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OatMilk.Backend.Api.Controllers.Security;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services
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

        public UserResponse GetUser(Guid userId)
        {
            var user = _repository.Get().FirstOrDefault(u => userId == u.Id);
            if (user == null) // Email check
            {
                throw new ArgumentException("User could not be found.", nameof(userId));
            }
            
            return _mapper.Map<User, UserResponse>(user); 
        }

        public AuthTokenResponse Login(UserLoginRequest request)
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
            return new AuthTokenResponse()
            {
                AuthToken = JWTHelper.GenerateToken(_configuration, user.Id)
            };
        }

        public async Task<AuthTokenResponse> Register(UserRegisterRequest request)
        {
            if(_repository.Get().Any(u => request.Email.ToLower() == u.Email.ToLower()))
            {
                throw new ArgumentException("User already exists.", nameof(request.Email));
            }

            // Create user
            var user = _mapper.Map<UserRegisterRequest, User>(request);
            user.Email = user.Email.ToLower();
            user.Password = SecurePasswordHasher.Hash(user.Password);
            user.CreatedUtc = DateTime.UtcNow;

            // Add user to database
            _repository.Add(user);
            await _repository.SaveAsync();

            // Create token for user
            return new AuthTokenResponse()
            {
                AuthToken = JWTHelper.GenerateToken(_configuration, user.Id)
            };
        }

        public bool UserExistsById(Guid userId)
        {
            return _repository.Get().Any(user => user.Id == userId);
        }
    }
}
