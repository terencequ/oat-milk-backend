using AutoMapper;
using OatMilk.Backend.Api.Modules.Characters.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Shared.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Business
{
    public class CharacterService : UserEntityService<CharacterRequest, Character, CharacterResponse>, ICharacterService
    {
        public CharacterService(IUserEntityRepository<Character> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}