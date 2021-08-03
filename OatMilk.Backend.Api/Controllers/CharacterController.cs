﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(CharacterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<CharacterResponse> GetByName(string name)
        {
            return await _service.GetByName(name);
        }
        
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