using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using NUnit.Framework;
using OatMilk.Backend.Api.Modules.Core.Security;
using OatMilk.Backend.Api.Modules.Users.Data;
using OatMilk.Backend.Api.Modules.Users.Domain;
using OatMilk.Backend.Api.Modules.Users.Domain.Models.Requests;
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
        
        #region GetByIdAsync

        [Test]
        public async Task GetByIdAsync_ValidId_ShouldReturnUserProfile()
        {
            var expectedId = ObjectId.GenerateNewId();
            var sut = new Fixture(new User(){Id = expectedId}, new User(){Id = ObjectId.GenerateNewId()})
                .GetSut();
            
            var result = await sut.GetByIdAsync(expectedId);
            Assert.AreEqual(expectedId.ToString(), result.Id);
        }

        [Test]
        public void GetByIdAsync_Invalid_ShouldThrowArgumentException()
        {
            var sut = new Fixture() // Empty user list
                .GetSut();

            async void Code() => await sut.GetByIdAsync(ObjectId.GenerateNewId());
            Assert.Throws<ArgumentException>(Code);
        }

        #endregion

        #region LoginAsync

        [Test]
        public async Task LoginAsync_Valid_ShouldReturnJWT()
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
            var result = await sut.LoginAsync(
                new UserLoginRequest()
                {
                    Email = expectedEmail, 
                    Password = expectedPassword
                });
            Assert.NotNull(result.AuthToken);
        }
        
        [Test]
        public void LoginAsync_InvalidEmail_ShouldThrowArgumentExceptionWithEmailParamName()
        {
            var sut = new Fixture(
                    new User()
                    {
                        Id = ObjectId.GenerateNewId(), 
                        Email = "wrong@wrong.com", 
                        Password = "wrong"
                    })
                .GetSut();
            var exception = Assert.Throws<ArgumentException>(()=> sut.LoginAsync(
                new UserLoginRequest()
                {
                    Email = "test@test.com", 
                    Password = SecurePasswordHasher.Hash("Test123456")
                }));
            Assert.AreEqual("Email", exception?.ParamName);
        }
        
        [Test]
        public void LoginAsync_InvalidPassword_ShouldThrowArgumentExceptionWithPasswordParamName()
        {
            const string expectedEmail = "test@test.com";
            var sut = new Fixture(new User(){ Id = ObjectId.GenerateNewId(), Email = expectedEmail, Password = SecurePasswordHasher.Hash("wrong")})
                .GetSut();

            async void Code() => await sut.LoginAsync(new UserLoginRequest()
            {
                Email = expectedEmail, 
                Password = SecurePasswordHasher.Hash("wrongpassword")
            });
            var exception = Assert.Throws<ArgumentException>(Code);
            Assert.AreEqual("Password", exception?.ParamName);
        }
        
        #endregion

        #region RegisterAsync

        [Test]
        public async Task RegisterAsync_Valid_ShouldReturnJWT()
        {
            const string expectedDisplayName = "test123";
            const string expectedEmail = "test@test.com";
            const string expectedPassword = "Password12";
            
            var sut = new Fixture().GetSut();
            var result = await sut.RegisterAsync(
                new UserRequest()
                {
                    DisplayName = expectedDisplayName,
                    Email = expectedEmail, 
                    Password = expectedPassword
                });
            Assert.NotNull(result.AuthToken);
        }
        
        [Test]
        public void RegisterAsync_EmailAlreadyExists_ShouldThrowArgumentExceptionWithEmailParamName()
        {
            const string expectedDisplayName = "test123";
            const string expectedEmail = "test@test.com";
            const string expectedPassword = "Password12";
            
            var sut = new Fixture(new User(){Id = ObjectId.GenerateNewId(), Email = expectedEmail, Password = "test123456778"}).GetSut();

            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await sut.RegisterAsync(
                new UserRequest()
                {
                    DisplayName = expectedDisplayName,
                    Email = expectedEmail, 
                    Password = expectedPassword
                }));
            
            Assert.AreEqual("Email", exception?.ParamName);
        }

        #endregion

        #region ExistsByIdAsync

        [Test]
        public async Task ExistsByIdAsync_UserExists_ShouldReturnTrue()
        {
            var expectedId = ObjectId.GenerateNewId();
            var sut = new Fixture(new User(){Id = expectedId}).GetSut();
            var result = await sut.ExistsByIdAsync(expectedId);
            Assert.IsTrue(result);
        }
        
        [Test]
        public async Task ExistsByIdAsync_UserDoesntExists_ShouldReturnFalse()
        {
            var sut = new Fixture(new User(){Id = ObjectId.GenerateNewId()}).GetSut();
            var result = await sut.ExistsByIdAsync(ObjectId.GenerateNewId());
            Assert.IsFalse(result);
        }
        
        #endregion
    }
}