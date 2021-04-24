using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
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
            public Fixture(params Ability[] abilities) : base(abilities) { }
            
            public AbilityService GetSut()
            {
                return new(Configuration, MockRepository.Object, Mapper);
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

        #region GetAbility

        [Test]
        public async Task GetAbility_AbilityExists_ShouldReturnAbilityResponse()
        {
            const string expectedName = "test";

            var service = new Fixture(new Ability(){ Name = expectedName }).GetSut();
            var result = await service.GetAbility(expectedName);
            Assert.AreEqual(expectedName, result.Name);
        }
        
        [Test]
        public void GetAbility_AbilityDoesntExist_ShouldThrowArgumentException()
        {
            const string expectedName = "test";

            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetAbility(expectedName));
        }

        #endregion
    }
}