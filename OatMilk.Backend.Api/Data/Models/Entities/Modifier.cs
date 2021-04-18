using OatMilk.Backend.Api.Data.Models.Enums;

namespace OatMilk.Backend.Api.Data.Models.Entities
{
    public class Modifier
    {
        /// <summary>
        /// Parent effect of this Modifier.
        /// </summary>
        public Effect Effect { get; set; }
        
        /// <summary>
        /// Path that points to an attribute (i.e. Hit points).
        /// </summary>
        public string Attribute { get; set; }
        
        /// <summary>
        /// Magnitude of the modifier.
        /// </summary>
        public float Magnitude { get; set; }
        
        /// <summary>
        /// The type of operation to be performed by the modifier.
        /// </summary>
        public ModifierOperation Operation { get; set; }
    }
}