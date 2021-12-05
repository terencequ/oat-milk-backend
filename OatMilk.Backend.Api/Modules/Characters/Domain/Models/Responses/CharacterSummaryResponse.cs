using System;
using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    /// <summary>
    /// A summarised character DTO used for the display of a character list.
    /// </summary>
    public class CharacterSummaryResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Identifier { get; set; }
        [Required] public DateTime CreatedDateTimeUtc { get; set; }
        [Required] public DateTime UpdatedDateTimeUtc { get; set; }
        [Required] public string Name { get; set; }
        
        // Level
        [Required] public int Level { get; set; }
        [Required] public int Experience { get; set; }
        [Required] public int PreviousLevelExperienceRequirement { get; set; }
        [Required] public int NextLevelExperienceRequirement { get; set; }
        
        // Health
        [Required] public int CurrentHitPoints { get; set; }
        [Required] public int MaxHitPoints { get; set; }
        [Required] public bool IsAlive { get; set; }
        
        // Flavour
        [Required] public string Backstory { get; set; }
        [Required] public string PersonalityTraits { get; set; }
        [Required] public string Ideals { get; set; }
        [Required] public string Bonds { get; set; }
        [Required] public string Flaws { get; set; }
        [Required] public string AlliesAndOrganisations { get; set; }
        [Required] public string Appearance { get; set; }
    }
}