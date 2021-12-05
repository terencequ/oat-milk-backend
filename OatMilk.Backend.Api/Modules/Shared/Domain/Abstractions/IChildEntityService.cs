using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Data;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions
{
    public interface IChildEntityService<TEntityChild>
    {
        Task<ICollection<TEntityChild>> GetAll(ObjectId entityId);

        Task SetAll(ObjectId entityId, ICollection<TEntityChild> newChildren);

        Task ClearAll(ObjectId entityId, ICollection<TEntityChild> newChildren);

        Task<TEntityChild> Get(ObjectId entityId, string childId);

        Task Add(ObjectId entityId, TEntityChild newChild);

        Task Update(ObjectId entityId, string childId, TEntityChild newChild);

        Task Delete(ObjectId entityId, string childId);
    }
}