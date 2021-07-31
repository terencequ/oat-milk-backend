using System;
using System.Linq;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Retrieve values as a queryable.
        /// Calls DbSet AsQueryable.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryable();

        /// <summary>
        /// Retrieve values as a queryable filtered by primary key ID.
        /// Calls DbSet AsQueryable.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetByIdQueryable(Guid id);

        /// <summary>
        /// Add a new entity to the database.
        /// Calls DbSet Add.
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        
        /// <summary>
        /// Save changes made to the oatMilkContext.
        /// Calls DbContext SaveChangesAsync.
        /// </summary>
        Task SaveAsync();

        /// <summary>
        /// Mark an entity for removal, which will take effect upon invoking <see cref="SaveAsync"/>.
        /// Calls DbContext Remove.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
    }
}