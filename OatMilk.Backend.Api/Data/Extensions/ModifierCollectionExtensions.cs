using System;
using System.Collections.Generic;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Enums;

namespace OatMilk.Backend.Api.Data.Extensions
{
    public static class ModifierCollectionExtensions
    {
        /// <summary>
        /// Ignoring attributes, aggregate all modifier values and operations to one value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public static double AggregateModifierValues(this ICollection<Modifier> modifiers, double baseValue)
        {
            double additive = 0d;
            double multiplicative = 1d;
            double division = 1d;
            double? overrideValue = null;

            foreach (var modifier in modifiers)
            {
                var magnitude = modifier.CalculateMagnitude();
                switch (modifier.Operation)
                {
                    case ModifierOperation.Add:
                        additive += magnitude;
                        break;
                    case ModifierOperation.Multiply:
                        multiplicative *= magnitude;
                        break;
                    case ModifierOperation.Divide:
                        division *= magnitude;
                        break;
                    case ModifierOperation.Override:
                        overrideValue = magnitude;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(modifier), $"Modifier of type {modifier.Operation} is not accounted for!");
                }
            }

            return overrideValue ?? ((baseValue + additive) * multiplicative) / division;
        }
    }
}