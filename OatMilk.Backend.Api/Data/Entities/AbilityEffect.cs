using System;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class AbilityEffect
    {
        public Ability Ability { get; set; }
        public Guid AbilityId { get; set; }
        
        public Effect Effect { get; set; }
        public Guid EffectId { get; set; }
    }
}