using AutoMapper;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Shared.Repositories.Abstraction;
using OatMilk.Backend.Api.Shared.Services.Abstractions;

namespace OatMilk.Backend.Api.Services
{
    public class CharacterService : UserEntityService<CharacterRequest, Character, CharacterResponse>, ICharacterService
    {
        public CharacterService(IUserEntityRepository<Character> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}