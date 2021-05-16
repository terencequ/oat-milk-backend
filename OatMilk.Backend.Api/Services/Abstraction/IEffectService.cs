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
        /// <returns>New modifier.</returns>
        Task<ModifierResponse> CreateModifier(Guid id, ModifierRequest request);

        /// <summary>
        /// Update an existing modifier assigned to the effect.
        /// </summary>
        /// <param name="id">Id of the effect</param>
        /// <param name="modifierId">Id of the modifier.</param>
        /// <param name="modifierRequest">Updated modifier properties.</param>
        /// <returns>Updated modifier.</returns>
        Task<ModifierResponse> UpdateModifier(Guid id, Guid modifierId, ModifierRequest modifierRequest);
        
        /// <summary>
        /// Delete a modifier from this existing effect.
        /// </summary>
        /// <param name="id">Id of the effect.</param>
        /// <param name="modifierId">Id of the modifier.</param>
        /// <returns>Deleted modifier.</returns>
        Task<ModifierResponse> DeleteModifer(Guid id, Guid modifierId);
    }
}