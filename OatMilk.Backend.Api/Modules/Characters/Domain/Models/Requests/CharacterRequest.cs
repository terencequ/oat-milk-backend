using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction;
using OatMilk.Backend.Api.Modules.Spells.Domain.Models.Requests;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests
{
    public class CharacterRequest : INamedRequest
    {
        [Required]
        [MinLength(DataConstants.MinLengthName)]
        [MaxLength(DataConstants.MaxLengthName)]
        public string Name { get; set; }
    }
}