using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    /// <summary>
    /// Character ability score proficiency response DTO.
    /// </summary>
    public class CharacterAbilityScoreProficiencyResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public bool Proficient { get; set; }
        [Required] public bool Expertise { get; set; }
    }
}