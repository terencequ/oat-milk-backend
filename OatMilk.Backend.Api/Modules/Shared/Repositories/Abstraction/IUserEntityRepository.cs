using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction
{
    public interface IUserEntityRepository<TEntity> : IRepository<TEntity> where TEntity : IUserEntity
    {
        ObjectId? GetCurrentUserIdOrDefault();
        
        ObjectId GetCurrentUserId();
    }
}