using System.Threading.Tasks;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses;
using OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Abstractions
{
    public interface ICharacterService : IUserEntityService<CharacterRequest, CharacterResponse>
    {
        Task<PageResponse<CharacterSummaryResponse>> GetMultipleAsSummaryAsync(SearchableSortedPageFilter filter);
    }
}