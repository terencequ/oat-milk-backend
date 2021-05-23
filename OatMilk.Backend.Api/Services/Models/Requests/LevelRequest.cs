using OatMilk.Backend.Api.Services.Models.Abstraction;

namespace OatMilk.Backend.Api.Services.Models.Requests
{
    public class LevelRequest : NamedRequest
    {
        public int Number { get; set; }
        public int ExperienceRequirement { get; set; }
        public int ProficiencyBonus { get; set; }
    }
}