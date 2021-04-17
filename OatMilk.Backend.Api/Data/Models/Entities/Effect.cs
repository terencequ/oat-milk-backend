using OatMilk.Backend.Api.Data.Models.Enums;

namespace OatMilk.Backend.Api.Data.Models.Entities
{
    public class Effect
    {
        public string Name { get; set; }
        public User User { get; set; }
        public int Duration { get; set; }
        public int Period { get; set; }
        public float ChanceToApplyToTarget { get; set; }

        /// <summary>
        /// Return duration type.
        ///     Duration = Effect will be applied periodically for the duration
        ///     Instant = Effect will be applied instantly, once
        ///     Infinite = Effect will be applied periodically for infinite duration
        /// </summary>
        /// <returns>Duration Type, based on the Duration property.</returns>
        public DurationType GetDurationType()
        {
            return Duration switch
            {
                > 0 => DurationType.Duration,
                0 => DurationType.Instant,
                _ => DurationType.Infinite
            };
        }
    }
}