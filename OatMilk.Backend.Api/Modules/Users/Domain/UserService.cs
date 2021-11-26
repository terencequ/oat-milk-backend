﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Core.Security;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;
using OatMilk.Backend.Api.Modules.Users.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Users.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Users.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Users.Data;

namespace OatMilk.Backend.Api.Modules.Users.Business
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

        public UserResponse GetUser(ObjectId userId)
        {
            var user = _repository.Get().FirstOrDefault(u => userId == u.Id);
            if (user == null) // Email check
            {
                throw new ArgumentException("User could not be found.", nameof(userId));
            }
            
            return _mapper.Map<User, UserResponse>(user); 
        }

        public UserAuthTokenResponse Login(UserLoginRequest request)
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
            return new UserAuthTokenResponse()
            {
                AuthToken = JWTHelper.GenerateToken(_configuration, user.Id)
            };
        }

        public async Task<UserAuthTokenResponse> Register(UserRequest request)
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

        public bool UserExistsById(ObjectId userId)
        {
            return _repository.Get().Any(user => user.Id == userId);
        }
    }
}