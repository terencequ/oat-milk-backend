using System;
using MongoDB.Bson;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Shared.Repositories.Abstraction
{
    public interface IUserEntityRepository<TEntity> : IRepository<TEntity> where TEntity : IUserEntity
    {
        ObjectId? GetCurrentUserIdOrDefault();
        
        ObjectId GetCurrentUserId();
    }
}