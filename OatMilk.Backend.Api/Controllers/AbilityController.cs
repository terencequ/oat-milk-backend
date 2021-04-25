using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

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
        
        /// <summary>
        /// Create a new ability.
        /// </summary>
        /// <param name="request">Parameters for new ability.</param>
        /// <returns>Id of newly created ability.</returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> CreateAbility([FromBody] AbilityRequest request)
        {
            try
            {
                return await _service.CreateAbility(request);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Get existing ability by name.
        /// </summary>
        /// <param name="name">Name of existing ability.</param>
        /// <returns>Existing ability.</returns>
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AbilityResponse>> GetAbilityByName([FromRoute] string name)
        {
            try
            {
                return await _service.GetAbilityByName(name);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
        /// <summary>
        /// Update an existing ability.
        /// </summary>
        /// <param name="id">Id of existing ability.</param>
        /// <param name="request">Updated ability parameters.</param>
        /// <returns>Updated ability.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AbilityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AbilityResponse>> UpdateAbility([FromRoute] Guid id, [FromBody] AbilityRequest request)
        {
            try
            {
                return await _service.UpdateAbility(id, request);
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
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAbility([FromRoute] Guid id)
        {
            try
            {
                await _service.DeleteAbility(id);
                return Ok();
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}