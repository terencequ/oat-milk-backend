using System.Collections.Generic;
using AutoMapper;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Domain;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Domain
{
    public class CharacterSpellService : ChildEntityService<Character, CharacterSpell>, ICharacterSpellService
    {
        public CharacterSpellService(IRepository<Character> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        protected override ICollection<CharacterSpell> GetChildrenNavigation(Character entity)
        {
            return entity.Spells;
        }
    }
}