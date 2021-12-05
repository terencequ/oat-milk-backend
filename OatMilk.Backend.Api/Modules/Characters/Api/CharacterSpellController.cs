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
    public class CharacterSpellController : ControllerBase
    {
        private readonly ICharacterSpellService _service;

        public CharacterSpellController(ICharacterSpellService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}/spell/{spellId}")]
        [ProducesResponseType(typeof(CharacterSpell), StatusCodes.Status200OK)]
        public async Task<CharacterSpell> Get(string id, string spellId)
        {
            var result = await _service.Get(ObjectId.Parse(id), spellId);
            return result;
        }
        
        [HttpPost("{id}/spell")]
        [ProducesResponseType(typeof(CharacterSpell), StatusCodes.Status200OK)]
        public async Task Add(string id, CharacterSpell spell)
        {
            await _service.Add(ObjectId.Parse(id), spell);
        }
        
        [HttpPut("{id}/spell/{spellId}")]
        [ProducesResponseType(typeof(CharacterSpell), StatusCodes.Status200OK)]
        public async Task Update(string id, string spellId, CharacterSpell spell)
        {
            await _service.Update(ObjectId.Parse(id), spellId, spell);
        }
        
        [HttpPut("{id}/spell/{spellId}")]
        [ProducesResponseType(typeof(CharacterSpell), StatusCodes.Status200OK)]
        public async Task Delete(string id, string spellId)
        {
            await _service.Delete(ObjectId.Parse(id), spellId);
        }
    }
}