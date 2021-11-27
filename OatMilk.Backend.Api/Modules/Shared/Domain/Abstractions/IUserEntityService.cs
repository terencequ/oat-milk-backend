using System.Threading.Tasks;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions
{
    public interface IUserEntityService<in TRequest, TResponse> : IEntityService<TRequest, TResponse>
    {
        Task<TResponse> GetByIdentifierAsync(string id);
        Task<PageResponse<TResponse>> GetMultipleAsync(SearchableSortedPageFilter filter);
    }
}