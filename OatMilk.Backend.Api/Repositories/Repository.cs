using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Models.Entities;

namespace OatMilk.Backend.Api.Repositories
{
    public interface IRepository<TEntity> where TEntity :class
    {
        Task<TEntity> FindAsync(params object[] keyValues);
        
        IQueryable<TEntity> Get();

        void Add(TEntity entity);
        
        Task SaveAsync();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private readonly DbSet<TEntity> _dbSet;
        
        public Repository(Context context)
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