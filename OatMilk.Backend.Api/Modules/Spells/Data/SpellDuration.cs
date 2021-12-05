using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Data
{
    public class SpellDuration
    {
        public int Value { get; set; }
        public SpellDurationType Type { get; set; }
        public string Description { get; set; }
    }
}