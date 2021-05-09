using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IAbilityService : IUserEntityService<AbilityRequest, AbilityResponse>
    {
        /// <summary>
        /// Get a list of entities. This is sortable, filterable and able to be paginated.
        /// </summary>
        /// <param name="filter">Filter which determines what page to view, and what to sort by.</param>
        /// <returns>Existing ability.</returns>
        Task<PageResponse<AbilityResponse>> GetMultiple(SearchableSortedPageFilter filter);
    }
}