using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Controllers.Models;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterLevelController : ControllerBase
    {
        private readonly ICharacterLevelService _characterLevelService;

        public CharacterLevelController(ICharacterLevelService characterLevelService)
        {
            _characterLevelService = characterLevelService;
        }
        
        [HttpPost("setup")]
        [ProducesResponseType(typeof(ICollection<LevelResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ICollection<LevelResponse>> ResetLevels()
        {
            return await _characterLevelService.ResetLevels();
        }
    }
}