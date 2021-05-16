using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;
        }
        
        [HttpPost("")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CharacterResponse>> CreateCharacter([FromBody] CharacterRequest request)
        {
            return await _service.Create(request);
        }
        
        
        [HttpGet("")]
        [ProducesResponseType(typeof(PageResponse<EffectResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PageResponse<CharacterResponse>>> GetCharacters([FromQuery] SearchableSortedPageFilter filter)
        {
            return await _service.GetMultiple(filter);
        }
        
        
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(EffectResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CharacterResponse>> GetCharacterByName([FromRoute] string name)
        {
            return await _service.GetByName(name);
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(EffectResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CharacterResponse>> UpdateCharacter([FromRoute] Guid id, [FromBody] CharacterRequest request)
        {

            return await _service.Update(id, request);
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCharacter([FromRoute] Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}