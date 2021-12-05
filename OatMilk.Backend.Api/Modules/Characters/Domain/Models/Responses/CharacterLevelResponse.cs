using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    /// <summary>
    /// This is a summary of a character's experience, along with some values calculated from that.
    /// </summary>
    public class CharacterLevelResponse
    {
        [Required] public int Number { get; set; }
        [Required] public int Experience { get; set; }
        [Required] public int CurrentLevelExperienceRequirement { get; set; }
        [Required] public int NextLevelExperienceRequirement { get; set; }
    }
}