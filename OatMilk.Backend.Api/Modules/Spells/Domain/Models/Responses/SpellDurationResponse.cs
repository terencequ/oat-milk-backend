using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Models.Responses
{
    public class SpellDurationResponse
    {
        [Required] public int Value { get; set; }
        [Required] public SpellDurationType Type { get; set; }
        [Required] public string Description { get; set; }
    }
}