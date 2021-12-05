using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Models.Requests
{
    public class SpellCastingTimeRequest
    {
        public int Value { get; set; }
        public SpellCastingTimeType Type { get; set; }
        public bool IsRitual { get; set; }
        public string Description { get; set; }
    }
}