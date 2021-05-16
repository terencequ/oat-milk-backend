using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.Language;
using Moq.Language.Flow;

namespace OatMilk.Backend.Api.Tests.TestingHelpers
{
    public static class DbSetMocking
    {
        /// <summary>
        /// Helper method to create a mock DbSet, populated with data.
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static Mock<DbSet<T>> CreateMockSet<T>(IQueryable<T> data)
            where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider)
                .Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression)
                .Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType)
                .Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                .Returns(queryableData.GetEnumerator());
            return mockSet;
        }

        /// <summary>
        /// Mock DbSet with an array of data.
        /// </summary>
        /// <param name="setup"></param>
        /// <param name="entities"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
            this IReturns<TContext, DbSet<TEntity>> setup,
            TEntity[] entities)
            where TEntity : class
            where TContext : class
        {
            var mockSet = CreateMockSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }

        /// <summary>
        /// Mock DbSet with an IQueryable of data.
        /// </summary>
        /// <param name="setup"></param>
        /// <param name="entities"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
            this IReturns<TContext, DbSet<TEntity>> setup,
            IQueryable<TEntity> entities)
            where TEntity : class
            where TContext : class
        {
            var mockSet = CreateMockSet(entities);
            return setup.Returns(mockSet.Object);
        }

        /// <summary>
        /// Mock DbSet with an IEnumerable of data.
        /// </summary>
        /// <param name="setup"></param>
        /// <param name="entities"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
            this IReturns<TContext, DbSet<TEntity>> setup,
            IEnumerable<TEntity> entities)
            where TEntity : class
            where TContext : class
        {
            var mockSet = CreateMockSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }
    }
}