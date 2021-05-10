using OatMilk.Backend.Api.Services.Models.Enums;

namespace OatMilk.Backend.Api.Services.Models.Responses
{
    public class ModifierResponse
    {
        public string Attribute { get; set; }
        
        public float Magnitude { get; set; }
        
        public ModifierOperation Operation { get; set; }
    }
}