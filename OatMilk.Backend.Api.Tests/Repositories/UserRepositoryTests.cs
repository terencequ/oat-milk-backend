using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.AutoMapper;
using OatMilk.Backend.Api.Data.Models.Entities;
using OatMilk.Backend.Api.Data.Models.Requests;
using OatMilk.Backend.Api.Repositories;
using OatMilk.Backend.Api.Security;
using OatMilk.Backend.Api.Tests.TestingHelpers;

namespace OatMilk.Backend.Api.Tests.Repositories
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private class Fixture : IFixture<UserRepository>
        {
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;
            private readonly Mock<Context> _mockContext;
            
            public Fixture(params User[] users)
            {
                _configuration = new ConfigurationBuilder().AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("Auth:UserTokenSecret", "this is a test secret key")
                }).Build();
                
                _mockContext = new Mock<Context>();
                _mockContext
                    .Setup(c => c.User)
                    .ReturnsDbSet(users);

                _mapper = new MapperConfiguration(config => config.AddProfile<UserProfile>())
                    .CreateMapper();
            }
            
            public UserRepository GetSut()
            {
                return new UserRepository(_configuration, _mockContext.Object, _mapper);
            }

            public Mock<Context> GetMockContext()
            {
                return _mockContext;
            }
        }
        
        [Test]
        public void GetUser_ValidId_ShouldReturnUserProfile()
        {
            var expectedId = Guid.NewGuid();
            var sut = new Fixture(new User(){Id = expectedId}, new User(){Id = Guid.NewGuid()})
                .GetSut();
            
            var result = sut.GetUser(expectedId);
            Assert.AreEqual(expectedId, result.Id);
        }

        [Test]
        public void GetUser_Invalid_ShouldThrowArgumentException()
        {
            var sut = new Fixture() // Empty user list
                .GetSut();
            Assert.Throws<ArgumentException>(()=> sut.GetUser(Guid.NewGuid()));
        }

        [Test]
        public void Login_Valid_ShouldReturnJWT()
        {
            var expectedEmail = "test@test.com";
            var expectedPassword = "Password12";
            
            var sut = new Fixture(
                    new User()
                    {
                        Id = Guid.NewGuid(), 
                        Email = expectedEmail, 
                        Password = SecurePasswordHasher.Hash(expectedPassword)
                    })
                .GetSut();
            var result = sut.Login(
                new UserLoginRequest()
                {
                    Email = expectedEmail, 
                    Password = expectedPassword
                });
            Assert.NotNull(result.AuthToken);
        }
        
        [Test]
        public void Login_InvalidEmail_ShouldThrowArgumentExceptionWithEmailParamName()
        {
            var sut = new Fixture(
                    new User()
                    {
                        Id=Guid.NewGuid(), 
                        Email = "wrong@wrong.com", 
                        Password = "wrong"
                    })
                .GetSut();
            var exception = Assert.Throws<ArgumentException>(()=> sut.Login(
                new UserLoginRequest()
                {
                    Email = "test@test.com", 
                    Password = SecurePasswordHasher.Hash("Test123456")
                }));
            Assert.AreEqual("Email", exception.ParamName);
        }
        
        [Test]
        public void Login_InvalidPassword_ShouldThrowArgumentExceptionWithPasswordParamName()
        {
            var expectedEmail = "test@test.com";
            var sut = new Fixture(new User(){ Id=Guid.NewGuid(), Email = expectedEmail, Password = SecurePasswordHasher.Hash("wrong")})
                .GetSut();
            var exception = Assert.Throws<ArgumentException>(()=> sut.Login(
                new UserLoginRequest()
                {
                    Email = expectedEmail, 
                    Password = SecurePasswordHasher.Hash("wrongpassword")
                }));
            Assert.AreEqual("Password", exception.ParamName);
        }
    }
}