using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Controllers.Security;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public abstract class BasicRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DbSet<TEntity> _entityDbSet;
        private readonly DbSet<User> _userDbSet;

        protected BasicRepository(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _entityDbSet = context.GetDbSet<TEntity>();
            _userDbSet = context.GetDbSet<User>();
        }

        /// <summary>
        /// Find a value given a set of keys.
        /// Calls DbSet FindAsync.
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _entityDbSet.FindAsync(keyValues);
        }

        /// <summary>
        /// Retrieve values as a queryable.
        /// Calls DbSet AsQueryable.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> Get()
        {
            return _entityDbSet.AsQueryable();
        }

        /// <summary>
        /// Add a new entity to the database. Will attach user ID if the entity is a <see cref="AbstractUserEntity"/>.
        /// Calls DbSet Add.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            if (typeof(TEntity).IsSubclassOf(typeof(AbstractUserEntity)))
            {
                var abstractUserEntity = entity as AbstractUserEntity;

                // Find and assign user
                var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
                var user = _userDbSet.Find(identity.GetUserId());
                if (abstractUserEntity != null) abstractUserEntity.User = user;
            }
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
    }
}