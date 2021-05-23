namespace OatMilk.Backend.Api.Services.Models.Responses
{
    public class CharacterLevelResponse
    {
        public string Name { get; set; }
        public int NextLevelExperienceRequirement { get; set; }
        public int PreviousLevelExperienceRequirement { get; set; }
        public int ExperienceRequirement { get; set; }
        public int ProficiencyBonus { get; set; }
    }
}