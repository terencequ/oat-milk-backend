using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    public class CharacterResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Identifier { get; set; }
        [Required] public DateTime CreatedDateTimeUtc { get; set; }
        [Required] public DateTime UpdatedDateTimeUtc { get; set; }
        [Required] public string Name { get; set; }
        [Required] public CharacterLevelResponse Level { get; set; }
        [Required] public List<CharacterAttributeResponse> Attributes { get; set; }
        [Required] public List<CharacterAbilityScoreResponse> AbilityScores { get; set; }
        [Required] public List<CharacterDescriptionResponse> Descriptions { get; set; }
    }

    #region Calculated responses

    public class CharacterLevelResponse
    {
        [Required] public int Level { get; set; }
        [Required] public int Experience { get; set; }
        [Required] public int PreviousLevelExperienceRequirement { get; set; }
        [Required] public int NextLevelExperienceRequirement { get; set; }
    }

    #endregion
    
    #region Responses that mirror database structure
    
    public class CharacterAttributeResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int CurrentValue { get; set; }
        [Required] public int DefaultValue { get; set; }
    }
    
    public class CharacterDescriptionResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Value { get; set; }
    }
    
    public class CharacterAbilityScoreResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Value { get; set; }
        [Required] public bool Proficient { get; set; }
        [Required] public bool Expertise { get; set; }
        [Required] public List<CharacterAbilityScoreProficiencyResponse> Proficiencies { get; set; }
    }

    public class CharacterAbilityScoreProficiencyResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public bool Proficient { get; set; }
        [Required] public bool Expertise { get; set; }
    }
    
    #endregion
}