using System;
using OatMilk.Backend.Api.Data.Entities.Abstraction;
using OatMilk.Backend.Api.Services.Models.Enums;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class Modifier : Entity
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
        public double Magnitude { get; set; }
        
        /// <summary>
        /// The type of operation to be performed by the modifier.
        /// </summary>
        public ModifierOperation Operation { get; set; }

        /// <summary>
        /// Calculates the total magnitude.
        /// TODO: Change this when magnitude is properly implemented.
        /// </summary>
        /// <returns>Magnitude of this modifier.</returns>
        public double CalculateMagnitude()
        {
            return Magnitude;
        }
    }
}