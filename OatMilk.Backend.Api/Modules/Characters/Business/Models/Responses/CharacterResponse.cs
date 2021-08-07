using System;
using System.Collections.Generic;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses
{
    public class CharacterResponse
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string Name { get; set; }
        public CharacterLevelResponse Level { get; set; }
        public List<CharacterAttributeResponse> Attributes { get; set; }
        public List<CharacterAbilityScoreResponse> AbilityScores { get; set; }
        public List<CharacterDescriptionResponse> Descriptions { get; set; }
    }

    #region Calculated responses

    public class CharacterLevelResponse
    {
        public int Level { get; set; }
        public int Experience { get; set; }
        public int PreviousLevelExperienceRequirement { get; set; }
        public int NextLevelExperienceRequirement { get; set; }
    }

    #endregion
    
    #region Responses that mirror database structure
    
    public class CharacterAttributeResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CurrentValue { get; set; }
        public int DefaultValue { get; set; }
    }
    
    public class CharacterDescriptionResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class CharacterAbilityScoreResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
        public List<CharacterAbilityScoreProficiencyResponse> Proficiencies { get; set; }
    }

    public class CharacterAbilityScoreProficiencyResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
    }
    
    #endregion
}