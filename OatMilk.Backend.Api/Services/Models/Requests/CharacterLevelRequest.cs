using OatMilk.Backend.Api.Services.Models.Abstraction;

namespace OatMilk.Backend.Api.Services.Models.Requests
{
    public class CharacterLevelRequest : NamedRequest
    {
        public int NextLevelExperienceRequirement { get; set; }
        public int PreviousLevelExperienceRequirement { get; set; }
        public int ExperienceRequirement { get; set; }
        public int ProficiencyBonus { get; set; }
    }
}