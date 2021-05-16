﻿using NUnit.Framework;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Enums;

namespace OatMilk.Backend.Api.Tests.Data.Entities
{
    [TestFixture]
    public class EffectTests
    {
        [Test]
        public void GetDurationType_DurationIsZero_IsInstant()
        {
            var effect = new Effect()
            {
                Duration = 0
            };
            Assert.AreEqual(DurationType.Instant, effect.GetDurationType());
        }
        
        [Test]
        public void GetDurationType_DurationIsNegative_IsInfinite()
        {
            var effect = new Effect()
            {
                Duration = -1
            };
            Assert.AreEqual(DurationType.Infinite, effect.GetDurationType());
        }
        
        [Test]
        public void GetDurationType_DurationIsAboveZero_IsDuration()
        {
            var effect = new Effect()
            {
                Duration = 1
            };
            Assert.AreEqual(DurationType.Duration, effect.GetDurationType());
        }
    }
}