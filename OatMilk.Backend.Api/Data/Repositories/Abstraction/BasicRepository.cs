using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OatMilk.Backend.Api.Data.Repositories.Abstraction
{
    public abstract class BasicRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BasicRepository(Context context)
        {
            _context = context;
            _dbSet = context.GetDbSet<TEntity>();
        }

        /// <summary>
        /// Find a value given a set of keys.
        /// Calls DbSet FindAsync.
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        /// <summary>
        /// Retrieve values as a queryable.
        /// Calls DbSet AsQueryable.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsQueryable();
        }

        /// <summary>
        /// Add a new entity to the database.
        /// Calls DbSet Add.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Save changes made to the context.
        /// Calls DbContext SaveChangesAsync.
        /// </summary>
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}