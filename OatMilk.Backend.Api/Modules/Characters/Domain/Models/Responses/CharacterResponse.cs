using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    /// <summary>
    /// Character response DTO.
    /// </summary>
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
        [Required] public List<CharacterSpellResponse> Spells { get; set; }
    }
}