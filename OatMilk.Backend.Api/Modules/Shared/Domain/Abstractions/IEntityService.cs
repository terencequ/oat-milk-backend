using System.Threading.Tasks;
using MongoDB.Bson;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions
{
    public interface IEntityService<in TRequest, TResponse>
    {
        /// <summary>
        /// Create and persist a new entity.
        /// </summary>
        /// <param name="request">Object details for new entity.</param>
        /// <returns></returns>
        Task<TResponse> CreateAsync(TRequest request);
        
        /// <summary>
        /// Get an entity by its id.
        /// </summary>
        /// <param name="id">Id of existing entity.</param>
        /// <returns></returns>
        Task<TResponse> GetByIdAsync(ObjectId id);
        
        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="id">Id of existing entity.</param>
        /// <param name="request">Object details for new entity.</param>
        /// <returns></returns>
        Task<TResponse> UpdateAsync(ObjectId id, TRequest request);
        
        /// <summary>
        /// Delete an existing entity.
        /// </summary>
        /// <param name="id">Id of existing entity.</param>
        /// <returns></returns>
        Task DeleteAsync(ObjectId id);
    }
}