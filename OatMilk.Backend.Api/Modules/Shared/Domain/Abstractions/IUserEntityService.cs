using System.Threading.Tasks;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions
{
    public interface IUserEntityService<in TRequest, TResponse> : IEntityService<TRequest, TResponse>
    {
        /// <summary>
        /// Get an entity by its user readable identifier.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        Task<TResponse> GetByIdentifierAsync(string identifier);
        
        /// <summary>
        /// Get multiple full entities owned by the logged in user.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PageResponse<TResponse>> GetMultipleAsync(SearchableSortedPageFilter filter);
    }
}