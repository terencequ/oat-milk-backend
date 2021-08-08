using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses
{
    public class CharacterResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Identifier { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        [Required] public string Name { get; set; }
        [Required] public CharacterLevelResponse Level { get; set; }
        [Required] public List<CharacterAttributeResponse> Attributes { get; set; }
        [Required] public List<CharacterAbilityScoreResponse> AbilityScores { get; set; }
        [Required] public List<CharacterDescriptionResponse> Descriptions { get; set; }
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
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        public int CurrentValue { get; set; }
        public int DefaultValue { get; set; }
    }
    
    public class CharacterDescriptionResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class CharacterAbilityScoreResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
        public List<CharacterAbilityScoreProficiencyResponse> Proficiencies { get; set; }
    }

    public class CharacterAbilityScoreProficiencyResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
    }
    
    #endregion
}