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
    public class EffectServiceTests
    {
        private class Fixture : RepositoryFixture<Effect>
        {
            public Fixture(params Effect[] effects) : base(effects){}

            public EffectService GetSut()
            {
                return new(Configuration, MockRepository.Object, Mapper);
            }
        }
        
        #region CreateEffect

        [Test]
        public async Task CreateAbilityForUser_ValidParameters_ShouldReturnEffectResponse()
        {
            var expectedName = "test name";
            var service = new Fixture().GetSut();
            var result = await service.CreateEffect(new EffectRequest()
            {
                Name = expectedName
            });
            Assert.AreEqual(expectedName, result.Name);
        }

        [Test]
        public void CreateAbilityForUser_NameAlreadyExists_ShouldThrowArgumentException()
        {
            const string duplicateName = "test";
            var service = new Fixture(new Effect(){ Name = duplicateName }).GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await service.CreateEffect(new EffectRequest()
                {
                    Name = duplicateName
                });
            });
        }
        
        #endregion
        
        #region GetEffectByName

        [Test]
        public async Task GetEffectByName_EffectExists_ShouldReturnAbilityResponse()
        {
            const string expectedName = "test";

            var service = new Fixture(new Effect(){ Name = expectedName }).GetSut();
            var result = await service.GetEffectByName(expectedName);
            Assert.AreEqual(expectedName, result.Name);
        }
        
        [Test]
        public void GetEffectByName_EffectDoesntExist_ShouldThrowArgumentException()
        {
            const string expectedName = "test";

            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetEffectByName(expectedName));
        }
        
        #endregion
        
        #region UpdateEffect

        [Test]
        public async Task UpdateEffect_EffectExists_ShouldReturnEffectResponse()
        {
            var expectedId = Guid.NewGuid();
            const string expectedName = "new name";
            
            var service = new Fixture(new Effect()
            {
                Id = expectedId,
                Name = "name"
            }).GetSut();
            var result = await service.UpdateEffect(expectedId, new EffectRequest()
            {
                Name = expectedName
            });
            
            Assert.AreEqual(expectedName, result.Name);
        }
        
        [Test]
        public void UpdateAbility_EffectDoesntExist_ShouldThrowArgumentException()
        {
            const string expectedName = "new name";
            var service = new Fixture().GetSut();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.UpdateEffect(Guid.NewGuid(), new EffectRequest()
            {
                Name = expectedName
            }));
        }
        
        #endregion
        
        #region DeleteEffect

        [Test]
        public void DeleteEffect_EffectExists_Returns()
        {
            var expectedGuid = Guid.NewGuid();
            var service = new Fixture(new Effect()
            {
                Id = expectedGuid
            }).GetSut();

            Assert.DoesNotThrowAsync(async () => await service.DeleteEffect(expectedGuid));
        }
        
        [Test]
        public void DeleteEffect_EffectDoesntExist_ThrowsArgumentException()
        {
            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.DeleteEffect(Guid.NewGuid()));
        }
        
        #endregion
    }
}