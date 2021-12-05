namespace OatMilk.Backend.Api.Modules.Spells.Data.Enums
{
    public enum SpellRangeTargetType
    {
        /// <summary>
        /// Spell is cast on a self.
        /// </summary>
        Self = 0,
        
        /// <summary>
        /// Spell is cast on a touched target.
        /// </summary>
        Touch = 1,
        
        /// <summary>
        /// Spell is cast on a target that is in range.
        /// </summary>
        Ranged = 2,
    }
}