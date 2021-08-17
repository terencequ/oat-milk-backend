using System;
using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses
{
    public class CharacterSummaryResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Identifier { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        [Required] public string Name { get; set; }
        
        // Level
        public int Level { get; set; }
        public int Experience { get; set; }
        public int PreviousLevelExperienceRequirement { get; set; }
        public int NextLevelExperienceRequirement { get; set; }
        
        // Health
        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public bool IsAlive { get; set; }
    }
}