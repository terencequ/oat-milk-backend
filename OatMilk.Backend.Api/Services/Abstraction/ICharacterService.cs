using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface ICharacterService :  IUserEntityService<CharacterRequest, CharacterResponse>
    {
        
    }
}