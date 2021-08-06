using System;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules.Core.Security;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;
using OatMilk.Backend.Api.Modules.Users.Data;

namespace OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction
{
    public class UserEntityRepository<TEntity> : Repository<TEntity>, IUserEntityRepository<TEntity> where TEntity : class, IUserEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<User> _userRepository;

        public UserEntityRepository(IOptions<DatabaseOptions> databaseOptions, IHttpContextAccessor httpContextAccessor, IRepository<User> userRepository) : base(databaseOptions)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Retrieve values as a queryable. Will only retrieve values that are owned by the current user.
        /// Calls DbSet AsQueryable.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<TEntity> Get()
        {
            var userId = GetCurrentUserId();
            return base.Get().Where(entity => entity.UserId == userId);
        }
        
        /// <summary>
        /// Add a new entity to the database. Will attach user ID of current user.
        /// Calls DbSet Add.
        /// </summary>
        /// <param name="entity"></param>
        public override Task AddAsync(TEntity entity)
        {
            // Find and assign user
            var userId = GetCurrentUserIdOrDefault();
            var user = _userRepository.Get().FirstOrDefault(e => e.Id == userId);
            entity.UserId = user?.Id ?? throw new AuthenticationException("Id is not valid!");
            entity.CreatedDateTimeUtc = DateTime.UtcNow;
            entity.UpdatedDateTimeUtc = DateTime.UtcNow;
            return base.AddAsync(entity);
        }

        public override Task UpdateAsync(TEntity entity)
        {
            entity.UpdatedDateTimeUtc = DateTime.UtcNow;
            return base.UpdateAsync(entity);
        }
        
        public ObjectId? GetCurrentUserIdOrDefault()
        {
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            return identity.GetUserIdOrDefault();
        }
        
        public ObjectId GetCurrentUserId()
        {
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            var userId = identity.GetUserIdOrDefault();
            
            if (userId == null)
            {
                throw new Exception("User ID not found in current HttpContext.");
            }
            
            return userId.GetValueOrDefault();
        }
    }
}