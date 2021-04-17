namespace OatMilk.Backend.Api.Data.Models.Enums
{
    public enum DurationType
    {
        Instant, // Effect will be applied periodically for the duration
        Duration, // Effect will be applied instantly, once
        Infinite // Effect will be applied periodically for infinite duration
    }
}