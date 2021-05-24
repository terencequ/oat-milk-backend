using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Controllers.Models;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }
        
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(LevelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<LevelResponse> GetByName([FromRoute] string name)
        {
            return await _levelService.GetByName(name);
        }
        
        [HttpGet("")]
        [ProducesResponseType(typeof(PageResponse<LevelResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<PageResponse<LevelResponse>> GetMultiple([FromQuery] SearchableSortedPageFilter filter)
        {
            return await _levelService.GetMultiple(filter);
        }
        
        [HttpPost("setup")]
        [ProducesResponseType(typeof(ICollection<LevelResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<PageResponse<LevelResponse>> ResetLevels()
        {
            return await _levelService.ResetLevels();
        }
    }
}