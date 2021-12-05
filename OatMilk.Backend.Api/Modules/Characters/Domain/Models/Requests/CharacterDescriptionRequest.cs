using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests
{
    public class CharacterDescriptionRequest : INamedRequest, IUniqueRequest
    {
        [Required]
        [MinLength(DataConstants.MinLengthId)]
        [MaxLength(DataConstants.MaxLengthId)]
        public string Id { get; set; }

        [MaxLength(DataConstants.MaxLengthName)]
        public string Name { get; set; }
        public string Value { get; set; }
    }

}