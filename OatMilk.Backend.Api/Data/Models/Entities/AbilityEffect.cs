using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OatMilk.Backend.Api.Data.Models.Entities
{
    public class AbilityEffect
    {
        public Ability Ability { get; set; }
        public Guid AbilityId { get; set; }
        
        public Effect Effect { get; set; }
        public Guid EffectId { get; set; }
    }
}