using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;

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

        [HttpPost("")]
        public async Task<ActionResult<Guid>> CreateAbilityForUser(AbilityRequest request)
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
    }
}