using System;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.Abstraction.Interface
{
    public interface IEffectService
    {
        Task<EffectResponse> CreateEffect(EffectRequest request);
        Task<EffectResponse> GetEffectById(Guid id);
        Task<EffectResponse> GetEffectByName(string name);
        Task<EffectResponse> UpdateEffect(Guid id, EffectRequest request);
        Task DeleteEffect(Guid id);
    }
}