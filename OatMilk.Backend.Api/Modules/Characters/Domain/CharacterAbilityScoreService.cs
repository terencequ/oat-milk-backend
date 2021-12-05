using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Domain;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Domain
{
    public class CharacterAbilityScoreService : ChildEntityService<Character, CharacterAbilityScore>, ICharacterAbilityScoreService
    {
        public CharacterAbilityScoreService(IUserEntityRepository<Character> repository, IMapper mapper) : base(repository, mapper) { }

        protected override ICollection<CharacterAbilityScore> GetChildrenNavigation(Character entity)
        {
            return entity.AbilityScores;
        }
    }
}