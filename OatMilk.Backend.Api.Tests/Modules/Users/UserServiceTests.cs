using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using NUnit.Framework;
using OatMilk.Backend.Api.Modules.Core.Security;
using OatMilk.Backend.Api.Modules.Users.Business;
using OatMilk.Backend.Api.Modules.Users.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Users.Data;
using OatMilk.Backend.Api.Tests.TestingHelpers;

namespace OatMilk.Backend.Api.Tests.Modules.Users
{
    [TestFixture]
    public class UserServiceTests
    {
        private class Fixture : RepositoryFixture<User>
        {
            public Fixture(params User[] users) : base(users) { }
            
            public UserService GetSut()
            {
                return new(Configuration, MockRepository.Object, Mapper);
            }
        }
        
        #region GetUser

        [Test]
        public void GetUser_ValidId_ShouldReturnUserProfile()
        {
            var expectedId = ObjectId.GenerateNewId();
            var sut = new Fixture(new User(){Id = expectedId}, new User(){Id = ObjectId.GenerateNewId()})
                .GetSut();
            
            var result = sut.GetUser(expectedId);
            Assert.AreEqual(expectedId, result.Id);
        }

        [Test]
        public void GetUser_Invalid_ShouldThrowArgumentException()
        {
            var sut = new Fixture() // Empty user list
                .GetSut();
            Assert.Throws<ArgumentException>(()=> sut.GetUser(ObjectId.GenerateNewId()));
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
                        Id = ObjectId.GenerateNewId(), 
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
                        Id = ObjectId.GenerateNewId(), 
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
            var sut = new Fixture(new User(){ Id = ObjectId.GenerateNewId(), Email = expectedEmail, Password = SecurePasswordHasher.Hash("wrong")})
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
        public async Task Register_Valid_ShouldReturnJWT()
        {
            const string expectedDisplayName = "test123";
            const string expectedEmail = "test@test.com";
            const string expectedPassword = "Password12";
            
            var sut = new Fixture().GetSut();
            var result = await sut.Register(
                new UserRequest()
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
            
            var sut = new Fixture(new User(){Id = ObjectId.GenerateNewId(), Email = expectedEmail, Password = "test123456778"}).GetSut();

            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await sut.Register(
                new UserRequest()
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
            var expectedId = ObjectId.GenerateNewId();
            var sut = new Fixture(new User(){Id = expectedId}).GetSut();
            var result = sut.UserExistsById(expectedId);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void UserExistsById_UserDoesntExists_ShouldReturnFalse()
        {
            var sut = new Fixture(new User(){Id = ObjectId.GenerateNewId()}).GetSut();
            var result = sut.UserExistsById(ObjectId.GenerateNewId());
            Assert.IsFalse(result);
        }
        
        #endregion
    }
}