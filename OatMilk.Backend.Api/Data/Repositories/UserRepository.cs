using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Models.Entities;

namespace OatMilk.Backend.Api.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly Context _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(Context context)
        {
            _context = context;
            _dbSet = context.GetDbSet<User>();
        }

        /// <summary>
        /// Find a value given a set of keys.
        /// Calls DbSet FindAsync.
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<User> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        /// <summary>
        /// Retrieve values as a queryable.
        /// Calls DbSet AsQueryable.
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> Get()
        {
            return _dbSet.AsQueryable();
        }

        /// <summary>
        /// Add a new entity to the database.
        /// Calls DbSet Add.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(User entity)
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