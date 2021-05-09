using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public abstract class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly OatMilkContext _oatMilkContext;
        private readonly DbSet<TEntity> _entityDbSet;

        protected EntityRepository(OatMilkContext oatMilkContext)
        {
            _oatMilkContext = oatMilkContext;
            _entityDbSet = oatMilkContext.GetDbSet<TEntity>();
        }

        /// <summary>
        /// Retrieve values as a queryable.
        /// Calls DbSet AsQueryable.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Get()
        {
            return _entityDbSet.AsQueryable();
        }

        /// <summary>
        /// Add a new entity to the database.
        /// Calls DbSet Add.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(TEntity entity)
        {
            _entityDbSet.Add(entity);
        }

        /// <summary>
        /// Save changes made to the oatMilkContext.
        /// Calls DbContext SaveChangesAsync.
        /// </summary>
        public async Task SaveAsync()
        {
            await _oatMilkContext.SaveChangesAsync();
        }

        /// <summary>
        /// Mark an entity for removal, which will take effect upon invoking <see cref="SaveAsync"/>.
        /// Calls DbContext Remove.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            _oatMilkContext.Remove(entity);
        }
    }
}