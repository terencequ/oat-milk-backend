using System;

namespace OatMilk.Backend.Api.Services.Models.Responses
{
    public class AttributeResponse
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public double BaseValue { get; set; }
        public double CurrentValue { get; set; }
    }
}