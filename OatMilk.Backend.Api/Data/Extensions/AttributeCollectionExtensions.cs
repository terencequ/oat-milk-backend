using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OatMilk.Backend.Api.Data.Entities;
using Attribute = OatMilk.Backend.Api.Data.Entities.Attribute;

namespace OatMilk.Backend.Api.Data.Extensions
{
    public static class AttributeCollectionExtensions
    {
        /// <summary>
        /// Apply an effect to a collection of attributes.
        /// </summary>
        /// <param name="attributes">Attributes to apply the effect to.</param>
        /// <param name="effect">Effect to apply.</param>
        /// <returns>The modifiers that were applied.</returns>
        public static ICollection<Modifier> ApplyEffect(this ICollection<Attribute> attributes, Effect effect)
        {
            var appliedModifiers = new List<Modifier>();
            
            // Apply modifiers per attribute
            var groupedModifiers = effect.Modifiers.GroupBy(modifier => modifier.Attribute);
            foreach (var modifierGroup in groupedModifiers)
            {
                // Find attribute to apply modifiers to
                var attributeType = modifierGroup.Key;
                var modifiers = modifierGroup.ToList();
                var attribute = attributes.FirstOrDefault(attr => attr.Type == attributeType);
                
                // Apply modifiers
                if (attribute == null) continue;
                attribute.CurrentValue = modifiers.AggregateModifierValues(attribute.CurrentValue);
                appliedModifiers.AddRange(modifiers);
            }

            return appliedModifiers;
        }
    }
}