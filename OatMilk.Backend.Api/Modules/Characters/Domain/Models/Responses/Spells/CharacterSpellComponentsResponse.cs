using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses.Spells
{
    public class CharacterSpellComponentsResponse
    {
        [Required] public bool Verbal { get; set; }
        [Required] public string VerbalDescription { get; set; }
        
        [Required] public bool Somatic { get; set; }
        [Required] public string SomaticDescription { get; set; }
        
        [Required] public bool Material { get; set; }
        [Required] public string MaterialDescription { get; set; }
    }
}