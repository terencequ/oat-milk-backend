using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Enums;

namespace OatMilk.Backend.Api.Services.Models.Requests
{
    public class ModifierRequest
    {
        public string Attribute { get; set; }
        
        public float Magnitude { get; set; }
        
        public ModifierOperation Operation { get; set; }
    }
}