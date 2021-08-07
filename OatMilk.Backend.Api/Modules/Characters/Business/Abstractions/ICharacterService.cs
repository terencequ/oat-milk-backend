using System.Threading.Tasks;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Shared.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Abstractions
{
    public interface ICharacterService : IUserEntityService<CharacterRequest, CharacterResponse>
    {
        Task<PageResponse<CharacterSummaryResponse>> GetMultipleAsSummary(SearchableSortedPageFilter filter);
    }
}