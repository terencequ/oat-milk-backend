using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IAbilityService
    {
        Task<Guid> CreateAbility(AbilityRequest request);

        Task<AbilityResponse> GetAbilityById(Guid id);
        
        Task<AbilityResponse> GetAbilityByName(string name);

        Task<AbilityResponse> UpdateAbility(Guid id, AbilityRequest request);

        Task DeleteAbility(Guid id);

        Task AssignEffectToAbility(Guid abilityId, Guid effectId);
    }
}