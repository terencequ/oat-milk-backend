using OatMilk.Backend.Api.Modules.Spells.Data;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;
using OatMilk.Backend.Api.Modules.Spells.Domain.Models.Responses;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Mapping
{
    public static class SpellMappingExtensions
    {
        public static SpellCastingTimeResponse AsResponse(this SpellCastingTime castingTime)
        {
            return new SpellCastingTimeResponse()
            {
                Value = castingTime?.Value ?? 0,
                Type = castingTime?.Type ?? SpellCastingTimeType.Unspecified,
                IsRitual = castingTime?.IsRitual ?? false,
                Description = castingTime?.Description
            };
        }

        public static SpellRangeResponse AsResponse(this SpellRange range)
        {
            return new SpellRangeResponse()
            {
                TargetValue = range?.TargetValue ?? 0,
                TargetType = range?.TargetType ?? SpellRangeTargetType.Ranged,
                EffectValue = range?.EffectValue ?? 0,
                EffectType = range?.EffectType ?? SpellRangeEffectType.Target,
            };
        }

        public static SpellComponentsResponse AsResponse(this SpellComponents components)
        {
            return new SpellComponentsResponse()
            {
                Verbal = components?.Verbal ?? false,
                VerbalDescription = components?.VerbalDescription,
                Somatic = components?.Somatic ?? false,
                SomaticDescription = components?.SomaticDescription,
                Material = components?.Material ?? false,
                MaterialDescription = components?.MaterialDescription,
            };
        }

        public static SpellDurationResponse AsResponse(this SpellDuration duration)
        {
            return new SpellDurationResponse()
            {
                Value = duration?.Value ?? 0,
                Type = duration?.Type ?? SpellDurationType.Unspecified,
                Description = duration?.Description,
            };
        }
    }
}