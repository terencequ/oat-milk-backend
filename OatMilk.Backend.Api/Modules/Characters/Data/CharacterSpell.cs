using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;
using OatMilk.Backend.Api.Modules.Spells.Data;

namespace OatMilk.Backend.Api.Modules.Characters.Data
{
    public class CharacterSpell : Spell, IChildEntity 
    {
        public string Id { get; set; }
    }
}