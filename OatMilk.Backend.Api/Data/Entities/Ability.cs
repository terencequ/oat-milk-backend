﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class Ability : UserEntity
    {
        /// <summary>
        /// Determines the cost of this ability. Will be applied to the user of the ability.
        /// If the user cannot pay the cost, the ability will not be committed.
        /// </summary>
        [ForeignKey("CostEffectId")]
        public Effect CostEffect { get; set; }
        
        /// <summary>
        /// Determines the cooldown of this ability. Should be an ability with no modifiers, but a duration and period.
        /// </summary>
        [ForeignKey("CooldownEffectId")]
        public Effect CooldownEffect { get; set; }
        
        /// <summary>
        /// The list of effects which will be applied to the target.
        /// </summary>
        public ICollection<Effect> Effects { get; set; }
    }
}