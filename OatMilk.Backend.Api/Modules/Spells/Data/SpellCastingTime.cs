using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Data
{
    public class SpellCastingTime
    {
        public int Value { get; set; }
        public SpellCastingTimeType Type { get; set; }
        public bool IsRitual { get; set; }
        public string Description { get; set; }
    }
}