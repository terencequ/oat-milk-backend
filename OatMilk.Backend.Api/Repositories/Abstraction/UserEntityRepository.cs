using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Controllers.Security;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public abstract class UserEntityRepository<TEntity> : EntityRepository<TEntity> where TEntity : UserEntity
    {
        private readonly DbSet<User> _userDbSet;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected UserEntityRepository(OatMilkContext oatMilkContext, IHttpContextAccessor httpContextAccessor) : base(oatMilkContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _userDbSet = oatMilkContext.GetDbSet<User>();
        }

        /// <summary>
        /// Retrieve values as a queryable. Will only retrieve values that are owned by the current user.
        /// Calls DbSet AsQueryable.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<TEntity> Get()
        {
            var userId = GetCurrentUserId();
            return base.Get().Where(entity => entity.User.Id == userId);
        }
        
        /// <summary>
        /// Add a new entity to the database. Will attach user ID of current user.
        /// Calls DbSet Add.
        /// </summary>
        /// <param name="entity"></param>
        public override void Add(TEntity entity)
        {
            // Find and assign user
            var userId = GetCurrentUserIdOrDefault();
            var user = _userDbSet.Find(userId);
            entity.User = user;
            
            base.Add(entity);
        }
        
        private Guid? GetCurrentUserIdOrDefault()
        {
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            return identity.GetUserIdOrDefault();
        }
        
        private Guid? GetCurrentUserId()
        {
            var identity = _httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;
            var userId = identity.GetUserIdOrDefault();
            
            if (userId == null)
            {
                throw new Exception("User ID not found in current HttpContext.");
            }
            
            return userId;
        }
    }
}