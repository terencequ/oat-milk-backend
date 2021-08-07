using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Modules.Characters.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Core.Api.Models;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Characters.Api
{
    [Authorize]
    [ApiController]
    [Route("character/summary")]
    public class CharacterSummaryController
    {
        private readonly ICharacterService _service;

        public CharacterSummaryController(ICharacterService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(PageResponse<CharacterSummaryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<PageResponse<CharacterSummaryResponse>> GetMultiple([FromQuery] SearchableSortedPageFilter filter)
        {
            return await _service.GetMultipleAsSummary(filter);
        }
    }
}