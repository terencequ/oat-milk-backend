using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses.Spells
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
        [Required] public string CastingTime { get; set; }
        [Required] public string RangeOrArea { get; set; }
        [Required] public CharacterSpellComponentsResponse Components { get; set; }
        [Required] public CharacterSpellDurationResponse Duration { get; set; }
        [Required] public SpellSchool School { get; set; }
    }
}