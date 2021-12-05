using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;
using OatMilk.Backend.Api.Modules.Spells.Domain.Models.Responses;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    /// <summary>
    /// Character spell response DTO.
    /// </summary>
    public class CharacterSpellResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int Level { get; set; }
        [Required] public SpellCastingTimeResponse CastingTime { get; set; }
        [Required] public SpellRangeResponse Range { get; set; }
        [Required] public SpellComponentsResponse Components { get; set; }
        [Required] public SpellDurationResponse Duration { get; set; }
        [Required] public SpellSchool School { get; set; }
    }
}