using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using NUnit.Framework;
using OatMilk.Backend.Api.Tests.TestingHelpers;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models;

namespace OatMilk.Backend.Api.Tests.Services.Abstraction
{
    [TestFixture]
    public class EntityServiceTests
    {
        private class Fixture : RepositoryFixture<TestEntity>
        {
            public Fixture(params TestEntity[] effects) : base(effects){}

            public TestEntityService GetSut()
            {
                return new(MockRepository.Object, Mapper);
            }
        }
        
        #region Create

        [Test]
        public async Task Create_ValidParameters_ShouldReturnResponse()
        {
            var expectedString = "test";
            var service = new Fixture().GetSut();
            var result = await service.Create(new TestEntityRequest()
            {
                TestString = expectedString
            });
            Assert.AreEqual(expectedString, result.TestString);
        }

        #endregion

        #region GetById

        [Test]
        public async Task GetById_EntityExists_ShouldReturnAbilityResponse()
        {
            var expectedId = ObjectId.GenerateNewId();

            var service = new Fixture(new TestEntity(){ Id = expectedId }).GetSut();
            var result = await service.GetById(expectedId);
            Assert.AreEqual(expectedId, result.Id);
        }
        
        [Test]
        public void GetById_EntityDoesntExist_ShouldThrowArgumentException()
        {
            var expectedId = ObjectId.GenerateNewId();

            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetById(expectedId));
        }

        #endregion

        #region Update

        [Test]
        public async Task Update_EntityExists_ShouldReturnAbilityResponse()
        {
            var expectedId = ObjectId.GenerateNewId();
            const string expectedString = "new name";
            
            var service = new Fixture(new TestEntity()
            {
                Id = expectedId,
                TestString = "name"
            }).GetSut();
            var result = await service.Update(expectedId, new TestEntityRequest()
            {
                TestString = expectedString
            });
            
            Assert.AreEqual(expectedString, result.TestString);
        }
        
        [Test]
        public void UpdateAbility_AbilityDoesntExist_ShouldThrowArgumentException()
        {
            const string expectedString = "new name";
            var service = new Fixture().GetSut();

            Assert.ThrowsAsync<ArgumentException>(async () => await service.Update(ObjectId.GenerateNewId(), new TestEntityRequest()
            {
                TestString = expectedString
            }));
        }
        
        #endregion

        #region DeleteAbility

        [Test]
        public void DeleteEntity_EntityExists_Returns()
        {
            var expectedGuid = ObjectId.GenerateNewId();
            var service = new Fixture(new TestEntity()
            {
                Id = expectedGuid
            }).GetSut();

            Assert.DoesNotThrowAsync(async () => await service.Delete(expectedGuid));
        }
        
        [Test]
        public void DeleteEntity_EntityDoesntExist_ThrowsArgumentException()
        {
            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.Delete(ObjectId.GenerateNewId()));
        }
        
        #endregion
    }
}