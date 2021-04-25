using System;
using System.Linq;
using System.Threading.Tasks;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Tests.TestingHelpers;

namespace OatMilk.Backend.Api.Tests.Services
{
    [TestFixture]
    public class AbilityServiceTests
    {
        private class Fixture : RepositoryFixture<Ability>
        {
            private readonly Mock<IRepository<Effect>> _mockEffectRepository;
            
            public Fixture(params Ability[] abilities) : base(abilities){}
            
            public Fixture(Effect[] effects, Ability[] abilities) : base(abilities)
            {
                _mockEffectRepository = new Mock<IRepository<Effect>>();
                _mockEffectRepository.Setup(m => m.Get()).Returns(effects.AsQueryable().BuildMock().Object);
            }
            
            public AbilityService GetSut()
            {
                return new(Configuration, MockRepository.Object, _mockEffectRepository.Object, Mapper);
            }
        }
        
        #region CreateAbility

        [Test]
        public async Task CreateAbilityForUser_ValidParameters_ShouldReturnGuid()
        {
            var service = new Fixture().GetSut();
            var result = await service.CreateAbility(new AbilityRequest()
            {
                Name = "test name"
            });
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CreateAbilityForUser_NameAlreadyExists_ShouldThrowArgumentException()
        {
            const string duplicateName = "test";
            var service = new Fixture(new Ability(){ Name = duplicateName }).GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await service.CreateAbility(new AbilityRequest()
                {
                    Name = duplicateName
                });
            });
        }

        #endregion

        #region GetAbilityByName

        [Test]
        public async Task GetAbilityByName_AbilityExists_ShouldReturnAbilityResponse()
        {
            const string expectedName = "test";

            var service = new Fixture(new Ability(){ Name = expectedName }).GetSut();
            var result = await service.GetAbilityByName(expectedName);
            Assert.AreEqual(expectedName, result.Name);
        }
        
        [Test]
        public void GetAbilityByName_AbilityDoesntExist_ShouldThrowArgumentException()
        {
            const string expectedName = "test";

            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetAbilityByName(expectedName));
        }

        #endregion
        
        #region UpdateAbility

        [Test]
        public async Task UpdateAbility_AbilityExists_ShouldReturnAbilityResponse()
        {
            var expectedId = Guid.NewGuid();
            const string expectedName = "new name";
            
            var service = new Fixture(new Ability()
            {
                Id = expectedId,
                Name = "name"
            }).GetSut();
            var result = await service.UpdateAbility(expectedId, new AbilityRequest()
            {
                Name = expectedName
            });
            
            Assert.AreEqual(expectedName, result.Name);
        }
        
        [Test]
        public void UpdateAbility_AbilityDoesntExist_ShouldThrowArgumentException()
        {
            const string expectedName = "new name";
            var service = new Fixture().GetSut();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.UpdateAbility(Guid.NewGuid(), new AbilityRequest()
            {
                Name = expectedName
            }));
        }
        
        #endregion

        #region DeleteAbility

        [Test]
        public void DeleteAbility_AbilityExists_Returns()
        {
            var expectedGuid = Guid.NewGuid();
            var service = new Fixture(new Ability()
            {
                Id = expectedGuid
            }).GetSut();

            Assert.DoesNotThrowAsync(async () => await service.DeleteAbility(expectedGuid));
        }
        
        [Test]
        public void DeleteAbility_AbilityDoesntExist_ThrowsArgumentException()
        {
            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeleteAbility(Guid.NewGuid()));
        }
        
        #endregion

        #region CreateEffectForAbility

        [Test]
        public void CreateEffectForAbility_ExistingAbility_ShouldReturnGuid()
        {
        }

        #endregion
    }
}