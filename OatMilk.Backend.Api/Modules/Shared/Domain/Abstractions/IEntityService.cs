using System.Threading.Tasks;
using MongoDB.Bson;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions
{
    public interface IEntityService<in TRequest, TResponse>
    {
        Task<TResponse> Create(TRequest request);
        Task<TResponse> GetById(ObjectId id);
        Task<TResponse> Update(ObjectId id, TRequest request);
        Task Delete(ObjectId id);
    }
}