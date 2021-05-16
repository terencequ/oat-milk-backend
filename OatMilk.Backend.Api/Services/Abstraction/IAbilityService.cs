using System;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IAbilityService : IUserEntityService<AbilityRequest, AbilityResponse>
    {
        /// <summary>
        /// Assign an effect to this ability.
        /// </summary>
        /// <param name="abilityId"></param>
        /// <param name="effectId"></param>
        /// <returns></returns>
        Task<AbilityResponse> AssignEffect(Guid abilityId, Guid effectId);
        
        /// <summary>
        /// Unassign an effect from this ability.
        /// </summary>
        /// <param name="abilityId"></param>
        /// <param name="effectId"></param>
        /// <returns></returns>
        Task<AbilityResponse> UnassignEffect(Guid abilityId, Guid effectId);
    }
}