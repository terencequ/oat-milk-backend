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
        
        #region GetEffectFromName

        
        #endregion
        
        #region UpdateEffect

        
        #endregion
        
        #region DeleteEffect

        
        #endregion
    }
}