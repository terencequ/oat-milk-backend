using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IUserEntityService<TRequest, TResponse> : IEntityService<TRequest, TResponse>
    {
        Task<TResponse> GetByName(string id);
        Task<PageResponse<TResponse>> GetMultiple(SearchableSortedPageFilter filter);
    }
}