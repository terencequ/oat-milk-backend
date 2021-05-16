using System;

namespace OatMilk.Backend.Api.Services.Models.Responses
{
    public class AttributeResponse
    {
        public string Type { get; set; }
        public int BaseValue { get; set; }
        public int CurrentValue { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
    }
}