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
                _mockEffectRepository.Setup(m => m.GetQueryable()).Returns(effects.AsQueryable().BuildMock().Object);
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
                new Ability() { Id = expectedAbilityId, Effects = new List<Effect>() }
            };

            var expectedEffectId = Guid.NewGuid();
            var effects = new Effect[]
            {
                new Effect() { Id = expectedEffectId }
            };

            var service = new Fixture(effects, abilities).GetSut();
            await service.AssignEffect(expectedAbilityId, expectedEffectId);
            var effect = abilities.First().Effects.First();
            
            Assert.AreEqual(expectedEffectId, effect.Id);
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
                new Ability() { Id = expectedAbilityId, Effects = new List<Effect>() }
            };
            
            var effects = new Effect[] { };

            var service = new Fixture(effects, abilities).GetSut();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.AssignEffect(expectedAbilityId, Guid.NewGuid()));
        }

        #endregion

        #region UnassignEffect

        [Test]
        public async Task UnassignEffect_BothExisting_ShouldRemoveEffect()
        {
            var expectedEffectId = Guid.NewGuid();
            var effects = new Effect[]
            {
                new Effect() { Id = expectedEffectId }
            };
            
            var expectedAbilityId = Guid.NewGuid();
            var abilities = new Ability[]
            {
                new Ability()
                {
                    Id = expectedAbilityId, 
                    Effects = new List<Effect>()
                }
            };
            
            abilities.First().Effects.Add(effects.First());

            var service = new Fixture(effects, abilities).GetSut();
            await service.UnassignEffect(expectedAbilityId, expectedEffectId);

            Assert.IsTrue(abilities.First().Effects.All(effect => effect.Id != expectedEffectId));
        }
        
        [Test]
        public void UnassignEffect_EffectDoesntExist_ShouldThrowArgumentException()
        {
            var expectedAbilityId = Guid.NewGuid();
            var abilities = new Ability[]
            {
                new Ability()
                {
                    Id = expectedAbilityId,
                    Effects = new List<Effect>()
                }
            };
            var service = new Fixture(Array.Empty<Effect>(), abilities).GetSut();
            
            Assert.ThrowsAsync<ArgumentException>(async () => await service.UnassignEffect(expectedAbilityId, Guid.NewGuid()));
        }
        
        [Test]
        public void UnassignEffect_AbilityDoesntExist_ShouldThrowArgumentException()
        {
            var service = new Fixture(Array.Empty<Effect>(), Array.Empty<Ability>()).GetSut();
            
            Assert.ThrowsAsync<ArgumentException>(async () => await service.UnassignEffect(Guid.NewGuid(), Guid.NewGuid()));
        }

        #endregion
    }
}