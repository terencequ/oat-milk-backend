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
        private class Fixture
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
        
        #region GetUser

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

        #endregion

        #region Login

        [Test]
        public void Login_Valid_ShouldReturnJWT()
        {
            const string expectedEmail = "test@test.com";
            const string expectedPassword = "Password12";
            
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
            const string expectedEmail = "test@test.com";
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
        
        #endregion

        #region Register

        [Test]
        public void Register_Valid_ShouldReturnJWT()
        {
            const string expectedDisplayName = "test123";
            const string expectedEmail = "test@test.com";
            const string expectedPassword = "Password12";
            
            var sut = new Fixture().GetSut();
            var result = sut.Register(
                new UserRegisterRequest()
                {
                    DisplayName = expectedDisplayName,
                    Email = expectedEmail, 
                    Password = expectedPassword
                });
            Assert.NotNull(result.AuthToken);
        }
        
        [Test]
        public void Register_EmailAlreadyExists_ShouldThrowArgumentExceptionWithEmailParamName()
        {
            const string expectedDisplayName = "test123";
            const string expectedEmail = "test@test.com";
            const string expectedPassword = "Password12";
            
            var sut = new Fixture(new User(){Id = Guid.NewGuid(), Email = expectedEmail, Password = "test123456778"}).GetSut();

            var exception = Assert.Throws<ArgumentException>(() => sut.Register(
                new UserRegisterRequest()
                {
                    DisplayName = expectedDisplayName,
                    Email = expectedEmail, 
                    Password = expectedPassword
                }));
            
            Assert.AreEqual("Email", exception.ParamName);
        }

        #endregion

        #region UserExistsById

        [Test]
        public void UserExistsById_UserExists_ShouldReturnTrue()
        {
            var expectedId = Guid.NewGuid();
            var sut = new Fixture(new User(){Id = expectedId}).GetSut();
            var result = sut.UserExistsById(expectedId);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void UserExistsById_UserDoesntExists_ShouldReturnFalse()
        {
            var sut = new Fixture(new User(){Id = Guid.NewGuid()}).GetSut();
            var result = sut.UserExistsById(Guid.NewGuid());
            Assert.IsFalse(result);
        }
        
        #endregion
    }
}