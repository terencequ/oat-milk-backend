namespace OatMilk.Backend.Api.Modules.Spells.Domain.Models.Requests
{
    public class SpellComponentsRequest
    {
        public bool Verbal { get; set; }
        public string VerbalDescription { get; set; }
        
        public bool Somatic { get; set; }
        public string SomaticDescription { get; set; }
        
        public bool Material { get; set; }
        public string MaterialDescription { get; set; }
    }
}