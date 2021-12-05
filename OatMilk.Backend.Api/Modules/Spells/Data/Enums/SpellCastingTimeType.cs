using System;

namespace OatMilk.Backend.Api.Modules.Spells.Data.Enums
{
    public enum SpellCastingTimeType
    {
        Unspecified = 0,
        Seconds = 1,
        Minutes = 2,
        Hours = 3,
        Days = 4,
        Weeks = 5,
        Months = 6,
        Years = 7,
        Actions = 8,
        BonusAction = 9,
        Reaction = 10,
        Rounds = 11,
        Special = 12,
    }
}