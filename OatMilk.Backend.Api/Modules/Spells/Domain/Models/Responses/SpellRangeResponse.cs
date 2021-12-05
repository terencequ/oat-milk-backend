using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Models.Responses
{
    public class SpellRangeResponse
    {
        [Required] public int TargetValue { get; set; }
        [Required] public SpellRangeTargetType TargetType { get; set; }
        [Required] public int EffectValue { get; set; }
        [Required] public SpellRangeEffectType EffectType { get; set; }
        [Required] public string Description { get; set; }
    }
}