using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Models.Responses
{
    public class SpellComponentsResponse
    {
        [Required] public bool Verbal { get; set; }
        [Required] public string VerbalDescription { get; set; }
        
        [Required] public bool Somatic { get; set; }
        [Required] public string SomaticDescription { get; set; }
        
        [Required] public bool Material { get; set; }
        [Required] public string MaterialDescription { get; set; }
    }
}