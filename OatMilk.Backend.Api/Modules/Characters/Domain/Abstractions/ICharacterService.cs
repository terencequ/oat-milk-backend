using System.Threading.Tasks;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses;
using OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Abstractions
{
    public interface ICharacterService : IUserEntityService<CharacterRequest, CharacterResponse>
    {
        /// <summary>
        /// Get all characters, as summarised objects, for the logged in user.
        /// </summary>
        /// <param name="filter">Filter, which allows sorting and pagination</param>
        /// <returns></returns>
        Task<PageResponse<CharacterSummaryResponse>> GetMultipleAsSummaryAsync(SearchableSortedPageFilter filter);
    }
}