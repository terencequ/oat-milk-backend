using System;
using System.Collections.Generic;

namespace OatMilk.Backend.Api.Services.Models.Responses
{
    public class EffectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModifierResponse> Modifiers { get; set; }
    }
}