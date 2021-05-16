﻿using System;
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
    public class EffectController : ControllerBase
    {
        private readonly IEffectService _service;

        public EffectController(IEffectService service)
        {
            _service = service;
        }
        
        [HttpPost("")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EffectResponse>> Create([FromBody] EffectRequest request)
        {
            return await _service.Create(request);
        }
        
        
        [HttpGet("")]
        [ProducesResponseType(typeof(PageResponse<EffectResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PageResponse<EffectResponse>>> GetMultiple([FromQuery] SearchableSortedPageFilter filter)
        {
            return await _service.GetMultiple(filter);
        }
        
        
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(EffectResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EffectResponse>> GetByName([FromRoute] string name)
        {
            return await _service.GetByName(name);
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(EffectResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EffectResponse>> Update([FromRoute] Guid id, [FromBody] EffectRequest request)
        {

            return await _service.Update(id, request);
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
        
        [HttpPost("{id:guid}/Modifier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModifierResponse>> CreateModifier([FromRoute] Guid id, [FromBody] ModifierRequest modifierRequest)
        {
            return await _service.CreateModifier(id, modifierRequest);
        }
        
        [HttpPut("{id:guid}/Modifier/{modifierId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModifierResponse>> UpdateModifier([FromRoute] Guid id, [FromRoute] Guid modifierId, [FromBody] ModifierRequest modifierRequest)
        {
            return await _service.UpdateModifier(id, modifierId, modifierRequest);
        }
        
        [HttpDelete("{id:guid}/Modifier/{modifierId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModifierResponse>> DeleteModifier([FromRoute] Guid id, [FromRoute] Guid modifierId)
        {
            return await _service.DeleteModifer(id, modifierId);
        }
    }
}