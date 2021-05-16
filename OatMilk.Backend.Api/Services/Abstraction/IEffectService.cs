using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IEffectService : IUserEntityService<EffectRequest, EffectResponse>
    {
        /// <summary>
        /// Create and assign a new modifier to and existing effect.
        /// </summary>
        /// <param name="id">Id of the effect.</param>
        /// <param name="request">New modifier properties.</param>
        /// <returns></returns>
        Task<ModifierResponse> CreateModifier(Guid id, ModifierRequest request);

        /// <summary>
        /// Delete a modifier from this existing effect.
        /// </summary>
        /// <param name="id">Id of the effect.</param>
        /// <param name="modifierId">Id of the modifier.</param>
        /// <returns></returns>
        Task<ModifierResponse> DeleteModifer(Guid id, Guid modifierId);
    }
}