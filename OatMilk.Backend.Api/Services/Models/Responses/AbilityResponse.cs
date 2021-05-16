using System;
using System.Collections.Generic;

namespace OatMilk.Backend.Api.Services.Models.Responses
{
    public class AbilityResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<EffectResponse> Effects { get; set; }
    }
}