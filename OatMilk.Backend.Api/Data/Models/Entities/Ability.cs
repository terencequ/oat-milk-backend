using System.Collections;
using System.Collections.Generic;

namespace OatMilk.Backend.Api.Data.Models.Entities
{
    public class Ability
    {
        public string Name { get; set; }
        public User User { get; set; }
        
        /// <summary>
        /// Determines the cost of this ability. Will be applied to the user of the ability.
        /// If the user cannot pay the cost, the ability will not be committed.
        /// </summary>
        public Effect CostEffect { get; set; }
        
        /// <summary>
        /// Determines the cooldown of this ability. Should be an ability with no modifiers, but a duration and period.
        /// </summary>
        public Effect CooldownEffect { get; set; }
        
        /// <summary>
        /// The list of effects which will be applied to the target.
        /// </summary>
        public IEnumerable<Effect> Effects { get; set; }
    }
}