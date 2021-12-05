using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;
using OatMilk.Backend.Api.Modules.Spells.Domain.Models.Requests;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests
{
    /// <summary>
    /// Request model for spell creation.
    /// </summary>
    public class CharacterSpellRequest : INamedRequest, IUniqueRequest
    {
        /// <summary>
        /// Id of existing spell, or nominal id of new spell.
        /// </summary>
        [Required]
        [MinLength(DataConstants.MinLengthId)]
        [MaxLength(DataConstants.MaxLengthId)]
        public string Id { get; set; }
        
        /// <summary>
        /// Ticked if a new id should be auto-generated for this spell.
        /// </summary>
        public bool ShouldCreateNewId { get; set; }
        
        [MaxLength(DataConstants.MaxLengthName)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public SpellCastingTimeRequest CastingTime { get; set; }
        public string Range { get; set; }
        public SpellComponentsRequest Components { get; set; }
        public SpellDurationRequest Duration { get; set; }
        public SpellSchool School { get; set; }
    }
}