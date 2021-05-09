using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Filters;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IAbilityService
    {
        /// <summary>
        /// Create ability for current user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Guid of newly created ability.</returns>
        /// <exception cref="ArgumentException"></exception>
        Task<AbilityResponse> CreateAbility(AbilityRequest request);

        /// <summary>
        /// Get a list of abilities. This is sortable, filterable and able to be paginated.
        /// </summary>
        /// <param name="filter">Filter which determines what page to view, and what to sort by.</param>
        /// <returns>Existing ability.</returns>
        Task<PageResponse<AbilityResponse>> GetAbilities(AbilityFilter filter);
        
        /// <summary>
        /// Get single ability for current user by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AbilityResponse> GetAbilityById(Guid id);
        
        /// <summary>
        /// Get single ability for current user by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<AbilityResponse> GetAbilityByName(string name);

        /// <summary>
        /// Update an existing ability.
        /// </summary>
        /// <param name="id">Id of existing ability.</param>
        /// <param name="request">Updated ability parameters.</param>
        /// <returns>Updated ability.</returns>
        Task<AbilityResponse> UpdateAbility(Guid id, AbilityRequest request);

        /// <summary>
        /// Delete an existing ability.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentException"></exception>
        Task DeleteAbility(Guid id);

        /// <summary>
        /// Assign effect for existing ability.
        /// </summary>
        /// <param name="abilityId">Existing ability ID.</param>
        /// <param name="effectId">Existing effect ID.</param>
        /// <returns>Ability with updated effect list.</returns>
        Task AssignEffectToAbility(Guid abilityId, Guid effectId);
    }
}