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
        public async Task<ActionResult<EffectResponse>> CreateEffect([FromBody] EffectRequest request)
        {
            try
            {
                return await _service.Create(request);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
        
        [HttpGet("")]
        [ProducesResponseType(typeof(PageResponse<EffectResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PageResponse<EffectResponse>>> GetEffects([FromQuery] SearchableSortedPageFilter filter)
        {
            try
            {
                return await _service.GetMultiple(filter);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
        
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(EffectResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EffectResponse>> GetEffectByName([FromRoute] string name)
        {
            try
            {
                return await _service.GetByName(name);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(EffectResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EffectResponse>> UpdateEffect([FromRoute] Guid id, [FromBody] EffectRequest request)
        {
            try
            {
                return await _service.Update(id, request);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
        /// <summary>
        /// Delete an existing ability.
        /// </summary>
        /// <param name="id">Id of existing ability.</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteEffect([FromRoute] Guid id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}