using System.Collections.Generic;
using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Data.Extensions;
using OatMilk.Backend.Api.Services.Models.Enums;

namespace OatMilk.Backend.Api.Tests.Data.Extensions
{
    public class ModifierCollectionExtensions
    {
        #region AggregateModifierValues

        [Test]
        public void AggregateModifierValues_NoModifiers_ReturnsBaseValue()
        {
            const double baseValue = 10d;
            var modifiers = new List<Modifier>() { };
            
            Assert.AreEqual(baseValue, modifiers.AggregateModifierValues(baseValue));
        }

        [Test]
        public void AggregateModifierValues_AddModifier_ReturnsBaseValuePlusModifier()
        {
            const double expectedValue = 11.34d;
            const double baseValue = 10d;
            var modifiers = new List<Modifier>()
            {
                CreateModifierForTest(1.34d, ModifierOperation.Add)
            };
            
            Assert.AreEqual(expectedValue, modifiers.AggregateModifierValues(baseValue));
        }
        
        [Test]
        public void AggregateModifierValues_MultiplyModifier_ReturnsBaseValueTimesModifier()
        {
            const double expectedValue = 23d;
            const double baseValue = 10d;
            var modifiers = new List<Modifier>()
            {
                CreateModifierForTest(2.3d, ModifierOperation.Multiply)
            };
            
            Assert.AreEqual(expectedValue, modifiers.AggregateModifierValues(baseValue));
        }
        
        [Test]
        public void AggregateModifierValues_DivideModifier_ReturnsBaseValueDividedByModifier()
        {
            const double expectedValue = 5d;
            const double baseValue = 10d;
            var modifiers = new List<Modifier>()
            {
                CreateModifierForTest(2d, ModifierOperation.Divide)
            };
            
            Assert.AreEqual(expectedValue, modifiers.AggregateModifierValues(baseValue));
        }
        
        [Test]
        public void AggregateModifierValues_OverrideModifier_ReturnsOverriddenValue()
        {
            const double expectedValue = 2d;
            const double baseValue = 10d;
            var modifiers = new List<Modifier>()
            {
                CreateModifierForTest(2d, ModifierOperation.Override)
            };
            
            Assert.AreEqual(expectedValue, modifiers.AggregateModifierValues(baseValue));
        }
        
        [Test]
        public void AggregateModifierValues_ComplexModifiersNoOverride_ReturnsCorrectValue()
        {
            const double expectedValue = 20.25d; // ((10 + (2 + 1.5)) * 3) / 2 = 20.25
            const double baseValue = 10d;
            var modifiers = new List<Modifier>()
            {
                CreateModifierForTest(2d, ModifierOperation.Add),
                CreateModifierForTest(1.5d, ModifierOperation.Add),
                CreateModifierForTest(3d, ModifierOperation.Multiply),
                CreateModifierForTest(2d, ModifierOperation.Divide),
            };
            
            Assert.AreEqual(expectedValue, modifiers.AggregateModifierValues(baseValue));
        }
        
        [Test]
        public void AggregateModifierValues_ComplexModifiersWithOverride_ReturnsLatestOverrideValue()
        {
            const double expectedValue = 3d; // ((10 + (2 + 1.5)) * 3) / 2 = 20.25
            const double baseValue = 10d;
            var modifiers = new List<Modifier>()
            {
                CreateModifierForTest(2d, ModifierOperation.Add),
                CreateModifierForTest(1.5d, ModifierOperation.Add),
                CreateModifierForTest(3d, ModifierOperation.Multiply),
                CreateModifierForTest(2d, ModifierOperation.Divide),
                CreateModifierForTest(2d, ModifierOperation.Override),
                CreateModifierForTest(expectedValue, ModifierOperation.Override), // This should take precedent, since this was added last
            };
            
            Assert.AreEqual(expectedValue, modifiers.AggregateModifierValues(baseValue));
        }
        
        #endregion

        #region Helpers

        private static Modifier CreateModifierForTest(double magnitude, ModifierOperation operation)
        {
            return new ()
            {
                Magnitude = magnitude,
                Operation = operation
            };
        }

        #endregion
    }
}