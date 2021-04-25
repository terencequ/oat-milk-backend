using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public abstract class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private readonly DbSet<TEntity> _entityDbSet;

        protected EntityRepository(Context context)
        {
            _context = context;
            _entityDbSet = context.GetDbSet<TEntity>();
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
        /// Save changes made to the context.
        /// Calls DbContext SaveChangesAsync.
        /// </summary>
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Mark an entity for removal, which will take effect upon invoking <see cref="SaveAsync"/>.
        /// Calls DbContext Remove.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }
    }
}