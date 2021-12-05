using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Models.Requests
{
    public class SpellRangeRequest
    {
        public int TargetValue { get; set; }
        public SpellRangeTargetType TargetType { get; set; }
        public int EffectValue { get; set; }
        public SpellRangeEffectType EffectType { get; set; }
        public string Description { get; set; }
    }
}