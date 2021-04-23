﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OatMilk.Backend.Api.Data.Models.Enums;

namespace OatMilk.Backend.Api.Data.Models.Entities
{
    public class Effect
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public int Duration { get; set; }
        public int Period { get; set; }
        
        /// <summary>
        /// Determines the chance for this effect to apply.
        /// </summary>
        public float ChanceToApplyToTarget { get; set; }
        
        /// <summary>
        /// List of modifiers for this effect.
        /// When this effect is resolved, these modifiers will be aggregated to a single value.
        /// </summary>
        public IEnumerable<Modifier> Modifiers { get; set; }
        
        /// <summary>
        /// Abilities associated with this effect.
        /// </summary>
        public IEnumerable<Ability> Abilities { get; set; }

        /// <summary>
        /// Return duration type.
        ///     Duration = Effect will be applied periodically for the duration
        ///     Instant = Effect will be applied instantly, once
        ///     Infinite = Effect will be applied periodically for infinite duration
        /// </summary>
        /// <returns>Duration Type, based on the Duration property.</returns>
        public DurationType GetDurationType()
        {
            return Duration switch
            {
                > 0 => DurationType.Duration,
                0 => DurationType.Instant,
                _ => DurationType.Infinite
            };
        }
    }
}