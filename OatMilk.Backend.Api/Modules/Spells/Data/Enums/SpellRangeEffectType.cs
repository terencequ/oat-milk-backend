using Microsoft.AspNetCore.Components.Web;

namespace OatMilk.Backend.Api.Modules.Spells.Data.Enums
{
    public enum SpellRangeEffectType
    {
        /// <summary>
        /// Spell's effect is only on the specified targets.
        /// </summary>
        Target = 0,
        
        /// <summary>
        /// Cone effect. Value represents the cone's diameter and length. i.e. 15ft => 15ft from the spell origin and 15ft diameter.
        /// </summary>
        Cone = 1,
        
        /// <summary>
        /// Cube effect. Value represents the cube's side length. i.e. 1ft => 1ft x 1ft x 1ft cube.
        /// </summary>
        Cube = 2,
        
        /// <summary>
        /// Cylinder effect. Value represents the cylinder's radius.
        /// </summary>
        Cylinder = 3,
        
        /// <summary>
        /// Line effect. Value represents the line's length.
        /// </summary>
        Line = 4,
        
        /// <summary>
        /// Sphere effect. Value represents the sphere's radius.
        /// </summary>
        Sphere = 5,
        
        /// <summary>
        /// Square effect. Value represents the square's side length. i.e. 1ft => 1ft x 1ft square.
        /// </summary>
        Square = 6,
    }
}