using System;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses
{
    public class CharacterSummaryResponse
    {
        public string Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string Classes { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int PreviousLevelExperienceRequirement { get; set; }
        public int NextLevelExperienceRequirement { get; set; }
        public bool IsAlive { get; set; }
    }
}