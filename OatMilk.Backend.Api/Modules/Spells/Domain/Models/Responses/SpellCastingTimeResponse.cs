using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Models.Responses
{
    public class SpellCastingTimeResponse
    {
        [Required] public int Value { get; set; }
        [Required] public SpellCastingTimeType Type { get; set; }
        [Required] public bool IsRitual { get; set; }
        [Required] public string Description { get; set; }
    }
}