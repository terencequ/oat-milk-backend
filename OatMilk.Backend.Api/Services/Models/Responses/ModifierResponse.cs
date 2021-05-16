using System;
using OatMilk.Backend.Api.Services.Models.Enums;

namespace OatMilk.Backend.Api.Services.Models.Responses
{
    public class ModifierResponse
    {
        public Guid Id { get; set; }
        public string Attribute { get; set; }
        
        public double Magnitude { get; set; }
        
        public ModifierOperation Operation { get; set; }
    }
}