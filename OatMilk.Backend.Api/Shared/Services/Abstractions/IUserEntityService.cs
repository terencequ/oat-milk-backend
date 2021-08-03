using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Shared.Services.Abstractions
{
    public interface IUserEntityService<in TRequest, TResponse> : IEntityService<TRequest, TResponse>
    {
        Task<TResponse> GetByName(string id);
        Task<PageResponse<TResponse>> GetMultiple(SearchableSortedPageFilter filter);
    }
}