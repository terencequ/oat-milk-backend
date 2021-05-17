using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Controllers.Models;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AbilityController : Controller
    {
        private readonly IAbilityService _service;
        
        public AbilityController(IAbilityService service)
        {
            _service = service;
        }
        
        [HttpPost("")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AbilityResponse>> CreateAbility([FromBody] AbilityRequest request)
        {
            return await _service.Create(request);
        }
        
        [HttpGet("")]
        [ProducesResponseType(typeof(PageResponse<AbilityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PageResponse<AbilityResponse>>> GetAbilities([FromQuery] SearchableSortedPageFilter filter)
        {
            return await _service.GetMultiple(filter);
        }
        
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AbilityResponse>> GetByName([FromRoute] string name)
        {
            return await _service.GetByName(name);
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AbilityResponse>> Update([FromRoute] Guid id, [FromBody] AbilityRequest request)
        {
            return await _service.Update(id, request);
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.Delete(id); 
            return Ok();
        }
        
        [HttpPost("{id:guid}/Effect/{effectId:guid}")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AbilityResponse>> AssignEffect([FromRoute] Guid id, Guid effectId)
        {
            return await _service.AssignEffect(id, effectId);
        }
        
        [HttpDelete("{id:guid}/Effect/{effectId:guid}")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AbilityResponse>> UnassignEffect([FromRoute] Guid id, Guid effectId)
        {
            return await _service.UnassignEffect(id, effectId);
        }
    }
}