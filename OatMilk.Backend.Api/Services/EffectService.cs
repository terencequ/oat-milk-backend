using System;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services
{
    public class EffectService : IEffectService
    {
        public Task<Guid> CreateEffect(AbilityRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AbilityResponse> GetEffectFromName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<AbilityResponse> UpdateEffect(Guid id, AbilityRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEffect(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}