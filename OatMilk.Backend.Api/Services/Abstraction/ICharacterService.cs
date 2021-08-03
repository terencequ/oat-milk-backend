using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Shared.Services.Abstractions;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface ICharacterService : IUserEntityService<CharacterRequest, CharacterResponse>
    {
        
    }
}