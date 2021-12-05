using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Models.Requests
{
    public class SpellDurationRequest
    {
        public int Value { get; set; }
        public SpellDurationType Type { get; set; }
        public string Description { get; set; }
    }
}