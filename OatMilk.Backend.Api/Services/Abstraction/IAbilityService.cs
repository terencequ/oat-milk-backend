using System;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Models.Requests;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface IAbilityService
    {
        Task<Guid> CreateAbility(AbilityRequest request);
    }
}