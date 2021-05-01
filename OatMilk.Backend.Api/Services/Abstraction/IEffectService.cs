using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IEffectService
    {
        Task<EffectResponse> CreateEffect(EffectRequest request);
                
        Task<EffectResponse> GetEffectFromName(string name);

        Task<EffectResponse> UpdateEffect(Guid id, EffectRequest request);

        Task DeleteEffect(Guid id);
    }
}