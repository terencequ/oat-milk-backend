using System;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses
{
    public class CharacterResponse
    {
        public string Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string Name { get; set; }

        public CharacterLevelResponse Level { get; set; }
        public CharacterAbilitiesAndAttributesResponse AbilitiesAndAttributes { get; set; }
        public CharacterProficienciesResponse Proficiencies { get; set; }
        public CharacterDescriptionsResponse CharacterDescriptionsResponse { get; set; }
    }

    public class CharacterLevelResponse
    {
        public int Level { get; set; }
        public int PreviousLevelExperienceRequirement { get; set; }
        public int CurrentLevelExperienceRequirement { get; set; }
        public int NextLevelExperienceRequirement { get; set; }
        public int Experience { get; set; }
    }
    
    public class CharacterAbilitiesAndAttributesResponse
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public int SpeedInFt { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        
        public int DeathSaveSuccesses { get; set; }
        public int DeathSaveFailures { get; set; }
    }

    public class CharacterProficienciesResponse
    {
        public bool Acrobatics { get; set; }
        public bool AnimalHandling { get; set; }
        public bool Arcana { get; set; }
        public bool Athletics { get; set; }
        public bool Deception { get; set; }
        public bool History { get; set; }
        public bool Insight { get; set; }
        public bool Intimidation { get; set; }
        public bool Investigation { get; set; }
        public bool Medicine { get; set; }
        public bool Nature { get; set; }
        public bool Perception { get; set; }
        public bool Performance { get; set; }
        public bool Persuasion { get; set; }
        public bool Religion { get; set; }
        public bool SleightOfHand { get; set; }
        public bool Stealth { get; set; }
        public bool Survival { get; set; }
    }

    public class CharacterDescriptionsResponse
    {
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public string Backstory { get; set; }
        public string AlliesAndOrganisations { get; set; }
        public string Appearance { get; set; }
    }
}