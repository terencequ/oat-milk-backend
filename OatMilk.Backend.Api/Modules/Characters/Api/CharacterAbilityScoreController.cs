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
    public class CharacterAbilityScoreController : ControllerBase
    {
        private readonly ICharacterAbilityScoreService _service;

        public CharacterAbilityScoreController(ICharacterAbilityScoreService service)
        {
            _service = service;
        }
        
        [HttpGet("{id}/ability-score")]
        [ProducesResponseType(typeof(ICollection<CharacterAbilityScore>), StatusCodes.Status200OK)]
        public async Task<ICollection<CharacterAbilityScore>> GetAll(string id)
        {
            var result = await _service.GetAll(ObjectId.Parse(id));
            return result;
        }
        
        [HttpPost("{id}/ability-score")]
        [ProducesResponseType(typeof(ICollection<CharacterAbilityScore>), StatusCodes.Status200OK)]
        public async Task SetAll(string id, ICollection<CharacterAbilityScore> abilityScores)
        {
            await _service.SetAll(ObjectId.Parse(id), abilityScores);
        }
    }
}