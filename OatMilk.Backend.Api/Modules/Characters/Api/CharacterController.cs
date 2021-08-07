﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
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

        [HttpGet]
        [ProducesResponseType(typeof(PageResponse<CharacterResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<PageResponse<CharacterResponse>> GetMultiple([FromQuery] SearchableSortedPageFilter filter)
        {
            return await _service.GetMultiple(filter);
        }
        
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
        [HttpPost]
        [ProducesResponseType(typeof(CharacterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<CharacterResponse> Create(CharacterRequest request)
        {
            return await _service.Create(request);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CharacterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<CharacterResponse> Update(string id, CharacterRequest request)
        {
            return await _service.Update(ObjectId.Parse(id), request);
        }
        
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