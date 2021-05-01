using System.Linq;
using Moq;
using NUnit.Framework;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Tests.Services.Pagination
{
    public class PaginationExtensionsTests
    {
        private class Fixture
        {
            private readonly string[] _items;
            
            public Fixture(params string[] items)
            {
                _items = items;
            }
            
            public IQueryable<string> GetSut()
            {
                return _items.AsQueryable();
            }
        }

        [Test]
        public void GetPageResponse_Normal_ShouldReturnResponseWithPageIndex()
        {
            var queryable = new Fixture("test1", "test2", "test3", "test4").GetSut();

            var expectedPageIndex = 0;
            var response = queryable.GetPageResponse(new PageFilter() { PageIndex = expectedPageIndex, PageSize = 1 });
            
            Assert.AreEqual(expectedPageIndex, response.PageIndex);
        }
        
        [Test]
        public void GetPageResponse_PageIndexNegative_ShouldReturnResponseWithPageIndex0()
        {
            var queryable = new Fixture("test1", "test2", "test3", "test4").GetSut();
            
            var response = queryable.GetPageResponse(new PageFilter() { PageIndex = -10, PageSize = 1 });
            
            Assert.AreEqual(0, response.PageIndex);
        }
        
        [Test]
        public void GetPageResponse_PageSizeNegative_ShouldReturnResponseWithPageSizeMax()
        {
            var queryable = new Fixture("test1", "test2", "test3", "test4").GetSut();
            
            var response = queryable.GetPageResponse(new PageFilter() { PageIndex = 0, PageSize = -1 });
            
            Assert.AreEqual(queryable.Count(), response.PageSize);
        }
        
        [Test]
        public void GetPageResponse_Normal_ShouldReturnResponseWithPageSize()
        {
            var queryable = new Fixture("test1", "test2", "test3", "test4").GetSut();

            var expectedPageSize = 1;
            var response = queryable.GetPageResponse(new PageFilter() { PageIndex = 0, PageSize = expectedPageSize });
            
            Assert.AreEqual(expectedPageSize, response.PageSize);
        }

        [Test]
        public void GetPageResponse_Normal_ShouldReturnResponseWithItems()
        {
            var expectedResult = new string[] {"test1"};
            var queryable = new Fixture(expectedResult[0], "test2", "test3", "test4").GetSut();
            
            var response = queryable.GetPageResponse(new PageFilter() { PageIndex = 0, PageSize = 1 });
            
            Assert.AreEqual(expectedResult, response.Items.ToArray());
        }
        
        [Test]
        public void GetPageResponse_IndexExceedsMaximum_ShouldReturnResponseWithNoItems()
        {
            var expectedResult = new string[] {};
            var queryable = new Fixture("test1", "test2", "test3", "test4").GetSut();
            
            var response = queryable.GetPageResponse(new PageFilter() { PageIndex = 133, PageSize = 1 });
            
            Assert.AreEqual(expectedResult, response.Items.ToArray());
        }
        
        [Test]
        public void GetPageResponse_PageSizeExceedsMaximum_ShouldReturnResponseWithAllItems()
        {
            var expectedResult = new string[] {"test1", "test2", "test3", "test4"};
            var queryable = new Fixture(expectedResult[0], expectedResult[1], expectedResult[2], expectedResult[3]).GetSut();
            
            var response = queryable.GetPageResponse(new PageFilter() { PageIndex = 0, PageSize = 133 });
            
            Assert.AreEqual(expectedResult, response.Items.ToArray());
        }
    }
}