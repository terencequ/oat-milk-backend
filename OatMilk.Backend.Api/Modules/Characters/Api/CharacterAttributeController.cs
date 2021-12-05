using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Abstractions;

namespace OatMilk.Backend.Api.Modules.Characters.Api
{
    [Authorize]
    [ApiController]
    [Route("character/full")]
    public class CharacterAttributeController : ControllerBase
    {
        private readonly ICharacterAttributeService _service;

        public CharacterAttributeController(ICharacterAttributeService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}/attribute")]
        [ProducesResponseType(typeof(ICollection<CharacterAttribute>), StatusCodes.Status200OK)]
        public async Task<ICollection<CharacterAttribute>> GetAll(string id)
        {
            var result = await _service.GetAll(ObjectId.Parse(id));
            return result;
        }
        
        [HttpPost("{id}/attribute")]
        [ProducesResponseType(typeof(ICollection<CharacterAttribute>), StatusCodes.Status200OK)]
        public async Task SetAll(string id, ICollection<CharacterAttribute> attributes)
        {
            await _service.SetAll(ObjectId.Parse(id), attributes);
        }
    }
}