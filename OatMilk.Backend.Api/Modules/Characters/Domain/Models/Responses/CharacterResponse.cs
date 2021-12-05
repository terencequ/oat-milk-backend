using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Spells.Domain.Models.Responses;

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
        [Required] public List<CharacterAttribute> Attributes { get; set; }
        [Required] public List<CharacterAbilityScore> AbilityScores { get; set; }
        [Required] public List<CharacterDescription> Descriptions { get; set; }
        [Required] public List<CharacterSpell> Spells { get; set; }
    }
}