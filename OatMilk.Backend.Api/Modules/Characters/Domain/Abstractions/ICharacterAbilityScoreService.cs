using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Abstractions
{
    public interface ICharacterAbilityScoreService : IChildEntityService<CharacterAbilityScore>
    {
    }
}