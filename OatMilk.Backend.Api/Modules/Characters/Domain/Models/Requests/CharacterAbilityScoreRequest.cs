using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests
{
    public class CharacterAbilityScoreRequest : INamedRequest, IUniqueRequest
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
}