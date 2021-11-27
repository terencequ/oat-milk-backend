using System.Threading.Tasks;
using MongoDB.Bson;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions
{
    public interface IEntityService<in TRequest, TResponse>
    {
        Task<TResponse> CreateAsync(TRequest request);
        Task<TResponse> GetByIdAsync(ObjectId id);
        Task<TResponse> UpdateAsync(ObjectId id, TRequest request);
        Task DeleteAsync(ObjectId id);
    }
}