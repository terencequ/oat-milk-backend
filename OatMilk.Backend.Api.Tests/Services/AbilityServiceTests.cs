using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Repositories.Abstraction.Interface;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Services.Models.Filters;
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
                return new(Configuration, MockRepository.Object, _mockEffectRepository?.Object, Mapper);
            }
        }
        
        #region CreateAbility

        [Test]
        public async Task CreateAbility_ValidParameters_ShouldReturnAbilityResponse()
        {
            var expectedName = "test name";
            var service = new Fixture().GetSut();
            var result = await service.CreateAbility(new AbilityRequest()
            {
                Name = expectedName
            });
            Assert.AreEqual(expectedName, result.Name);
        }

        [Test]
        public void CreateAbility_NameAlreadyExists_ShouldThrowArgumentException()
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

        #region GetAbilityById

        [Test]
        public async Task GetAbilityById_AbilityExists_ShouldReturnAbilityResponse()
        {
            var expectedId = Guid.NewGuid();

            var service = new Fixture(new Ability(){ Id = expectedId }).GetSut();
            var result = await service.GetAbilityById(expectedId);
            Assert.AreEqual(expectedId, result.Id);
        }
        
        [Test]
        public void GetAbilityById_AbilityDoesntExist_ShouldThrowArgumentException()
        {
            var expectedId = Guid.NewGuid();

            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetAbilityById(expectedId));
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

        #region GetAbilities

        [Test]
        public async Task GetAbilities_SearchByName_ShouldOnlyReturnNamesContainingSearch()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var expectedName3 = "ates";
            var service = new Fixture(
                    new Ability() { Name = expectedName1 },
                    new Ability() { Name = expectedName2 },
                    new Ability() { Name = expectedName3 })
                .GetSut();
            var result = await service.GetAbilities(new AbilityFilter() {SearchByName = "test"});
            Assert.IsTrue(result.Items.Any(ability => ability.Name == expectedName1));
            Assert.IsTrue(result.Items.Any(ability => ability.Name == expectedName2));
            Assert.IsFalse(result.Items.Any(ability => ability.Name == expectedName3));
        }
        
        [Test]
        public async Task GetAbilities_FilterNameAscending_ShouldReturnInAscendingNameOrder()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var expectedName3 = "atest";
            var service = new Fixture(
                new Ability() { Name = expectedName1 },
                new Ability() { Name = expectedName2 },
                new Ability() { Name = expectedName3 })
                .GetSut();
            var result = await service.GetAbilities(new AbilityFilter() {SortColumnName = "name", SortAscending = true});
            Assert.AreEqual(expectedName3, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
            Assert.AreEqual(expectedName2, result.Items.ElementAt(2).Name);
        }
        
        [Test]
        public async Task GetAbilities_FilterNameDescending_ShouldReturnInDescendingNameOrder()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var expectedName3 = "atest";
            var service = new Fixture(
                    new Ability() { Name = expectedName1 },
                    new Ability() { Name = expectedName2 },
                    new Ability() { Name = expectedName3 })
                .GetSut();
            var result = await service.GetAbilities(new AbilityFilter() {SortColumnName = "name", SortAscending = false});
            Assert.AreEqual(expectedName2, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
            Assert.AreEqual(expectedName3, result.Items.ElementAt(2).Name);
        }
        
        [Test]
        public async Task GetAbilities_FilterCreatedDateTimeUtcAscending_ShouldReturnAscendingCreatedDateTimeUtc()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new Ability()
                {
                    Name = expectedName1,
                    CreatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Ability()
                {
                    Name = expectedName2,
                    CreatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetAbilities(new AbilityFilter()
            {
                SortColumnName = "createddatetimeutc",
                SortAscending = true
            });
            Assert.AreEqual(expectedName1, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName2, result.Items.ElementAt(1).Name);
        }
        
        [Test]
        public async Task GetAbilities_FilterCreatedDateTimeUtcDescending_ShouldReturnDescendingCreatedDateTimeUtc()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new Ability()
                {
                    Name = expectedName1,
                    CreatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Ability()
                {
                    Name = expectedName2,
                    CreatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetAbilities(new AbilityFilter()
            {
                SortColumnName = "createddatetimeutc",
                SortAscending = false
            });
            Assert.AreEqual(expectedName2, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
        }
        
                [Test]
        public async Task GetAbilities_FilterUpdatedDateTimeUtcAscending_ShouldReturnAscendingCreatedDateTimeUtc()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new Ability()
                {
                    Name = expectedName1,
                    UpdatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Ability()
                {
                    Name = expectedName2,
                    UpdatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetAbilities(new AbilityFilter()
            {
                SortColumnName = "updateddatetimeutc",
                SortAscending = true
            });
            Assert.AreEqual(expectedName1, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName2, result.Items.ElementAt(1).Name);
        }
        
        [Test]
        public async Task GetAbilities_FilterUpdatedDateTimeUtcDescending_ShouldReturnDescendingCreatedDateTimeUtc()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new Ability()
                {
                    Name = expectedName1,
                    UpdatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Ability()
                {
                    Name = expectedName2,
                    UpdatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetAbilities(new AbilityFilter()
            {
                SortColumnName = "updateddatetimeutc",
                SortAscending = false
            });
            Assert.AreEqual(expectedName2, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
        }
        
        [Test]
        public async Task GetAbilities_DefaultFilter_ShouldReturnInDescendingCreationDateOrder()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new Ability()
                {
                    Name = expectedName1,
                    CreatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Ability()
                {
                    Name = expectedName2,
                    CreatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetAbilities(new AbilityFilter());
            Assert.AreEqual(expectedName2, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
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

        #region AssignEffectToAbility

        [Test]
        public async Task AssignEffectToAbility_BothExisting_ShouldCreateNewAbilityEffect()
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
            await service.AssignEffectToAbility(expectedAbilityId, expectedEffectId);
            var abilityEffect = abilities.First().AbilityEffects.First();
            
            Assert.AreEqual(expectedEffectId, abilityEffect.Effect.Id);
            Assert.AreEqual(expectedAbilityId, abilityEffect.Ability.Id);
        }
        
        [Test]
        public void AssignEffectToAbility_AbilityDoesntExist_ShouldThrowArgumentException()
        {
            var abilities = new Ability[] { };

            var expectedEffectId = Guid.NewGuid();
            var effects = new Effect[]
            {
                new Effect() { Id = expectedEffectId }
            };
            
            var service = new Fixture(effects, abilities).GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.AssignEffectToAbility(Guid.NewGuid(), expectedEffectId));
        }
        
        [Test]
        public void AssignEffectToAbility_EffectDoesntExist_ShouldThrowArgumentException()
        {
            var expectedAbilityId = Guid.NewGuid();
            var abilities = new Ability[]
            {
                new Ability() { Id = expectedAbilityId, AbilityEffects = new List<AbilityEffect>() }
            };
            
            var effects = new Effect[] { };

            var service = new Fixture(effects, abilities).GetSut();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.AssignEffectToAbility(expectedAbilityId, Guid.NewGuid()));
        }


        #endregion
    }
}