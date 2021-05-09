using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Pagination;
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
                return new(MockRepository.Object, _mockEffectRepository?.Object, Mapper);
            }
        }

        #region AssignEffect

        [Test]
        public async Task AssignEffect_BothExisting_ShouldCreateNewAbilityEffect()
        {
            var expectedAbilityId = Guid.NewGuid();
            var abilities = new Ability[]
            {
                new Ability() { Id = expectedAbilityId, AbilityEffects = new List<AbilityEffect>() }
            };

            var expectedEffectId = Guid.NewGuid();
            var effects = new Effect[]
            {
                new Effect() { Id = expectedEffectId }
            };

            var service = new Fixture(effects, abilities).GetSut();
            await service.AssignEffect(expectedAbilityId, expectedEffectId);
            var abilityEffect = abilities.First().AbilityEffects.First();
            
            Assert.AreEqual(expectedEffectId, abilityEffect.Effect.Id);
            Assert.AreEqual(expectedAbilityId, abilityEffect.Ability.Id);
        }
        
        [Test]
        public void AssignEffect_AbilityDoesntExist_ShouldThrowArgumentException()
        {
            var abilities = new Ability[] { };

            var expectedEffectId = Guid.NewGuid();
            var effects = new Effect[]
            {
                new Effect() { Id = expectedEffectId }
            };
            
            var service = new Fixture(effects, abilities).GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.AssignEffect(Guid.NewGuid(), expectedEffectId));
        }
        
        [Test]
        public void AssignEffect_EffectDoesntExist_ShouldThrowArgumentException()
        {
            var expectedAbilityId = Guid.NewGuid();
            var abilities = new Ability[]
            {
                new Ability() { Id = expectedAbilityId, AbilityEffects = new List<AbilityEffect>() }
            };
            
            var effects = new Effect[] { };

            var service = new Fixture(effects, abilities).GetSut();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.AssignEffect(expectedAbilityId, Guid.NewGuid()));
        }


        #endregion
    }
}