using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses;
using OatMilk.Backend.Api.Modules.Core.Api.Models;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Characters.Api
{
    [Authorize]
    [ApiController]
    [Route("Character/full")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;
        }

        #region CRUD

        /// <summary>
        /// Get a paginated, filtered and sorted list of all existing characters, with all details.
        /// </summary>
        /// <param name="filter">Allows for sorting and filtering.</param>
        [HttpGet]
        [ProducesResponseType(typeof(PageResponse<CharacterResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<PageResponse<CharacterResponse>> GetMultiple([FromQuery] SearchableSortedPageFilter filter)
        {
            return await _service.GetMultiple(filter);
        }
        
        /// <summary>
        /// Get an existing character by its human-readable identifier.
        /// </summary>
        /// <param name="identifier">Human readable unique identifier.</param>
        [HttpGet("{identifier}")]
        [ProducesResponseType(typeof(CharacterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<CharacterResponse> GetByIdentifier(string identifier)
        {
            return await _service.GetByIdentifier(identifier);
        }
        
        /// <summary>
        /// Create a character.
        /// </summary>
        /// <param name="request">Details of new character.</param>
        [HttpPost]
        [ProducesResponseType(typeof(CharacterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<CharacterResponse> Create(CharacterRequest request)
        {
            return await _service.Create(request);
        }

        /// <summary>
        /// Update an existing character by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request">Details of new character.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CharacterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<CharacterResponse> Update(string id, CharacterRequest request)
        {
            return await _service.Update(ObjectId.Parse(id), request);
        }
        
        /// <summary>
        /// Delete an existing character by ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task Delete([FromRoute] string id)
        {
            await _service.Delete(ObjectId.Parse(id));
        }

        #endregion
    }
}