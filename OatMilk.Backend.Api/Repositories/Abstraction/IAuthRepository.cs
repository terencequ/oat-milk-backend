using System;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public interface IAuthRepository<TEntity> : IRepository<TEntity> where TEntity : UserEntity
    {
        Guid? GetCurrentUserIdOrDefault();
        
        Guid GetCurrentUserId();
    }
}