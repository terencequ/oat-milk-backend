using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    /// <summary>
    /// Character ability score response DTO.
    /// </summary>
    public class CharacterAbilityScoreResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Value { get; set; }
        [Required] public bool Proficient { get; set; }
        [Required] public bool Expertise { get; set; }
        [Required] public List<CharacterAbilityScoreProficiencyResponse> Proficiencies { get; set; }
    }
}