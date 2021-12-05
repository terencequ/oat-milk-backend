using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses.Spells
{
    public class CharacterSpellDurationResponse
    {
        public int Value { get; set; }
        public SpellDurationType Type { get; set; }
        public string Description { get; set; }
    }
}