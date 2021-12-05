using OatMilk.Backend.Api.Modules.Spells.Data.Enums;

namespace OatMilk.Backend.Api.Modules.Spells.Data
{
    public class SpellRange
    {
        /// <summary>
        /// Value for the range spell can be targeted. Only used for spells that target with a range.
        /// </summary>
        public int TargetValue { get; set; }
        
        /// <summary>
        /// Type of target range. i.e. Self, Touch, or Ranged.
        /// </summary>
        public SpellRangeTargetType TargetType { get; set; }
        
        /// <summary>
        /// Value for the range of the spell's effect.
        /// </summary>
        public int EffectValue { get; set; }
        
        /// <summary>
        /// Type of effect range. i.e. Cone, Sphere, Line, etc.
        /// </summary>
        public SpellRangeEffectType EffectType { get; set; }
        
        /// <summary>
        /// Extra description on the range of the spell.
        /// </summary>
        public string Description { get; set; }
    }
}