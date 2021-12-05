using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests.Spells
{
    public class CharacterSpellDurationRequest
    {
        public int Value { get; set; }
        public SpellDurationType Type { get; set; }
        public string Description { get; set; }
    }
}