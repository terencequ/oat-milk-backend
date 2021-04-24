using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services;
using OatMilk.Backend.Api.Services.Abstraction;

namespace OatMilk.Backend.Api.Controllers
{
    public class AbilityController
    {
        private readonly IAbilityService _service;
        
        public AbilityController(IAbilityService service)
        {
            _service = service;
        }
        
    }
}