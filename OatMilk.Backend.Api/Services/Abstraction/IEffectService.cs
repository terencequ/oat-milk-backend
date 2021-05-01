using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IEffectService
    {
        Task<Guid> CreateEffect(AbilityRequest request);
                
        Task<AbilityResponse> GetEffectFromName(string name);

        Task<AbilityResponse> UpdateEffect(Guid id, AbilityRequest request);

        Task DeleteEffect(Guid id);
    }
}