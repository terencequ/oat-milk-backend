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
        [Required] public string Classes { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Level { get; set; }
        [Required] public int Experience { get; set; }
        [Required] public int PreviousLevelExperienceRequirement { get; set; }
        [Required] public int NextLevelExperienceRequirement { get; set; }
        [Required] public bool IsAlive { get; set; }
    }
}