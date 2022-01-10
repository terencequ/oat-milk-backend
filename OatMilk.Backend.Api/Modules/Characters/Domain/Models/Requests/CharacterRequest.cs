using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests
{
    public class CharacterRequest : INamedRequest
    {
        [Required]
        [MinLength(DataConstants.MinLengthName)]
        [MaxLength(DataConstants.MaxLengthName)]
        public string Name { get; set; }

        /// <summary>
        /// A list of all attributes. If this is null, character's attributes won't be updated.
        /// </summary>
        public List<CharacterAttributeRequest> Attributes { get; set; }
        
        /// <summary>
        /// A list of all attributes. If this is null, character's ability scores won't be updated.
        /// </summary>
        public List<CharacterAbilityScoreRequest> AbilityScores { get; set; }
        
        /// <summary>
        /// A list of all ability score proficiencies. If this is null, character's proficiencies won't be updated.
        /// All requests here will be parented under existing ability scores.
        /// </summary>
        public List<CharacterAbilityScoreProficiencyRequest> AbilityScoreProficiencies { get; set; }
        
        /// <summary>
        /// A list of all attributes. If this is null, character's descriptions won't be updated.
        /// </summary>
        public List<CharacterDescriptionRequest> Descriptions { get; set; }
        
        /// <summary>
        /// A list of all spells. If this is null, character's spells won't be updated.
        /// </summary>
        public List<CharacterSpellRequest> Spells { get; set; }
    }
}