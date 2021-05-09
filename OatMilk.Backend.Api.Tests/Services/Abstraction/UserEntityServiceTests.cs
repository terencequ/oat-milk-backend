using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Pagination;
using OatMilk.Backend.Api.Tests.TestingHelpers;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models;

namespace OatMilk.Backend.Api.Tests.Services.Abstraction
{
    [TestFixture]
    public class UserEntityServiceTests
    {
        private class Fixture : RepositoryFixture<TestUserEntity>
        {
            public Fixture(params TestUserEntity[] effects) : base(effects){}

            public TestUserEntityService GetSut()
            {
                return new(MockRepository.Object, Mapper);
            }
        }
        
        #region GetEffectByName

        [Test]
        public async Task GetByName_EntityExists_ShouldReturnResponse()
        {
            const string expectedName = "test";

            var service = new Fixture(new TestUserEntity(){ Name = expectedName }).GetSut();
            var result = await service.GetByName(expectedName);
            Assert.AreEqual(expectedName, result.Name);
        }
        
        [Test]
        public void GetByName_EntityDoesntExist_ShouldThrowArgumentException()
        {
            const string expectedName = "test";

            var service = new Fixture().GetSut();
            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetByName(expectedName));
        }
        
        #endregion
        
        #region GetMultiple

        [Test]
        public async Task GetMultiple_SearchByName_ShouldOnlyReturnNamesContainingSearch()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var expectedName3 = "ates";
            var service = new Fixture(
                    new TestUserEntity() { Name = expectedName1 },
                    new TestUserEntity() { Name = expectedName2 },
                    new TestUserEntity() { Name = expectedName3 })
                .GetSut();
            var result = await service.GetMultiple(new SearchableSortedPageFilter() {SearchByName = "test"});
            Assert.IsTrue(result.Items.Any(ability => ability.Name == expectedName1));
            Assert.IsTrue(result.Items.Any(ability => ability.Name == expectedName2));
            Assert.IsFalse(result.Items.Any(ability => ability.Name == expectedName3));
        }
        
        [Test]
        public async Task GetMultiple_FilterNameAscending_ShouldReturnInAscendingNameOrder()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var expectedName3 = "atest";
            var service = new Fixture(
                new TestUserEntity() { Name = expectedName1 },
                new TestUserEntity() { Name = expectedName2 },
                new TestUserEntity() { Name = expectedName3 })
                .GetSut();
            var result = await service.GetMultiple(new SearchableSortedPageFilter() {SortColumnName = "name", SortAscending = true});
            Assert.AreEqual(expectedName3, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
            Assert.AreEqual(expectedName2, result.Items.ElementAt(2).Name);
        }
        
        [Test]
        public async Task GetMultiple_FilterNameDescending_ShouldReturnInDescendingNameOrder()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var expectedName3 = "atest";
            var service = new Fixture(
                    new TestUserEntity() { Name = expectedName1 },
                    new TestUserEntity() { Name = expectedName2 },
                    new TestUserEntity() { Name = expectedName3 })
                .GetSut();
            var result = await service.GetMultiple(new SearchableSortedPageFilter() {SortColumnName = "name", SortAscending = false});
            Assert.AreEqual(expectedName2, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
            Assert.AreEqual(expectedName3, result.Items.ElementAt(2).Name);
        }
        
        [Test]
        public async Task GetMultiple_FilterCreatedDateTimeUtcAscending_ShouldReturnAscendingCreatedDateTimeUtc()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new TestUserEntity()
                {
                    Name = expectedName1,
                    CreatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new TestUserEntity()
                {
                    Name = expectedName2,
                    CreatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetMultiple(new SearchableSortedPageFilter()
            {
                SortColumnName = "createddatetimeutc",
                SortAscending = true
            });
            Assert.AreEqual(expectedName1, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName2, result.Items.ElementAt(1).Name);
        }
        
        [Test]
        public async Task GetMultiple_FilterCreatedDateTimeUtcDescending_ShouldReturnDescendingCreatedDateTimeUtc()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new TestUserEntity()
                {
                    Name = expectedName1,
                    CreatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new TestUserEntity()
                {
                    Name = expectedName2,
                    CreatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetMultiple(new SearchableSortedPageFilter()
            {
                SortColumnName = "createddatetimeutc",
                SortAscending = false
            });
            Assert.AreEqual(expectedName2, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
        }
        
                [Test]
        public async Task GetMultiple_FilterUpdatedDateTimeUtcAscending_ShouldReturnAscendingCreatedDateTimeUtc()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new TestUserEntity()
                {
                    Name = expectedName1,
                    UpdatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new TestUserEntity()
                {
                    Name = expectedName2,
                    UpdatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetMultiple(new SearchableSortedPageFilter()
            {
                SortColumnName = "updateddatetimeutc",
                SortAscending = true
            });
            Assert.AreEqual(expectedName1, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName2, result.Items.ElementAt(1).Name);
        }
        
        [Test]
        public async Task GetMultiple_FilterUpdatedDateTimeUtcDescending_ShouldReturnDescendingCreatedDateTimeUtc()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new TestUserEntity()
                {
                    Name = expectedName1,
                    UpdatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new TestUserEntity()
                {
                    Name = expectedName2,
                    UpdatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetMultiple(new SearchableSortedPageFilter()
            {
                SortColumnName = "updateddatetimeutc",
                SortAscending = false
            });
            Assert.AreEqual(expectedName2, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
        }
        
        [Test]
        public async Task GetMultiple_DefaultFilter_ShouldReturnInDescendingCreationDateOrder()
        {
            var expectedName1 = "test1";
            var expectedName2 = "test2";
            var service = new Fixture(
                new TestUserEntity()
                {
                    Name = expectedName1,
                    CreatedDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new TestUserEntity()
                {
                    Name = expectedName2,
                    CreatedDateTimeUtc = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).GetSut();
            var result = await service.GetMultiple(new SearchableSortedPageFilter());
            Assert.AreEqual(expectedName2, result.Items.ElementAt(0).Name);
            Assert.AreEqual(expectedName1, result.Items.ElementAt(1).Name);
        }

        #endregion
    }
}