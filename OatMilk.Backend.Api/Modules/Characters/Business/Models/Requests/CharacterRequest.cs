using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Shared.Business.Models.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests
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
    }

    public class CharacterAttributeRequest
    {
        [Required]
        [MinLength(DataConstants.MinLengthId)]
        [MaxLength(DataConstants.MaxLengthId)]
        public string Id { get; set; }

        [MaxLength(DataConstants.MaxLengthName)]
        public string Name { get; set; }
        public int CurrentValue { get; set; }
        public int DefaultValue { get; set; }
    }
    
    public class CharacterDescriptionRequest
    {
        [Required]
        [MinLength(DataConstants.MinLengthId)]
        [MaxLength(DataConstants.MaxLengthId)]
        public string Id { get; set; }

        [MaxLength(DataConstants.MaxLengthName)]
        public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class CharacterAbilityScoreRequest
    {
        [Required]
        [MinLength(DataConstants.MinLengthId)]
        [MaxLength(DataConstants.MaxLengthId)]
        public string Id { get; set; }
        
        [MaxLength(DataConstants.MaxLengthName)]
        public string Name { get; set; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
    }

    public class CharacterAbilityScoreProficiencyRequest
    {
        [Required]
        [MinLength(DataConstants.MinLengthId)]
        [MaxLength(DataConstants.MaxLengthId)]
        public string AbilityScoreId { get; set; }
        
        [Required]
        [MinLength(DataConstants.MinLengthId)]
        [MaxLength(DataConstants.MaxLengthId)]
        public string Id { get; set; }
        
        [MaxLength(DataConstants.MaxLengthName)]
        public string Name { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
    }
}