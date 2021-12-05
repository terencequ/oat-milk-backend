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
    public class CharacterDescriptionController : ControllerBase
    {
        private readonly ICharacterDescriptionService _service;

        public CharacterDescriptionController(ICharacterDescriptionService service)
        {
            _service = service;
        }

        [HttpGet("{id}/description")]
        [ProducesResponseType(typeof(ICollection<CharacterDescription>), StatusCodes.Status200OK)]
        public async Task<ICollection<CharacterDescription>> GetAll(string id)
        {
            var result = await _service.GetAll(ObjectId.Parse(id));
            return result;
        }

        [HttpPost("{id}/description")]
        [ProducesResponseType(typeof(ICollection<CharacterDescription>), StatusCodes.Status200OK)]
        public async Task SetAll(string id, ICollection<CharacterDescription> descriptions)
        {
            await _service.SetAll(ObjectId.Parse(id), descriptions);
        }
    }
}