using System.Linq;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Helpers;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses;
using OatMilk.Backend.Api.Modules.Shared.Domain.Helpers;
using OatMilk.Backend.Api.Modules.Spells.Data.Enums;
using OatMilk.Backend.Api.Modules.Spells.Domain.Models.Responses;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Mapping
{
    public static class CharacterMappingExtensions
    {
        public static CharacterResponse AsResponse(this Character character)
        {
            var experience = character.Attributes.GetByIdOrDefault("experience")?.CurrentValue ?? -1;
            return new CharacterResponse()
            {
                Id = character.Id.ToString(),
                Identifier = character.Identifier,
                Name = character.Name,
                CreatedDateTimeUtc = character.CreatedDateTimeUtc,
                UpdatedDateTimeUtc = character.UpdatedDateTimeUtc,
                Level = new CharacterLevelResponse()
                {
                    Number = LevelHelper.GetLevel(experience),
                    Experience = experience,
                    CurrentLevelExperienceRequirement = LevelHelper.GetPreviousLevelExperienceRequirement(experience),
                    NextLevelExperienceRequirement = LevelHelper.GetNextLevelExperienceRequirement(experience),
                },
                AbilityScores = character.AbilityScores?
                    .Select(abilityScore => new CharacterAbilityScoreResponse()
                    {
                        Id = abilityScore.Id,
                        Name = abilityScore.Name,
                        Value = abilityScore.Value,
                        Expertise = abilityScore.Expertise,
                        Proficient = abilityScore.Proficient,
                        Proficiencies = abilityScore.Proficiencies?
                            .Select(proficiency => new CharacterAbilityScoreProficiencyResponse()
                            {
                                Id = proficiency.Id,
                                Name = proficiency.Name,
                                Expertise = proficiency.Expertise,
                                Proficient = proficiency.Proficient
                            }).ToList()
                    }).ToList(),
                Attributes = character.Attributes?
                    .Select(attribute => new CharacterAttributeResponse()
                    {
                        Id = attribute.Id,
                        Name = attribute.Name,
                        CurrentValue = attribute.CurrentValue,
                        DefaultValue = attribute.DefaultValue
                    }).ToList(),
                Descriptions = character.Descriptions?
                    .Select(description => new CharacterDescriptionResponse()
                    {
                        Id = description.Id,
                        Name = description.Name,
                        Value = description.Value
                    }).ToList(),
                Spells = character.Spells?
                    .Select(spell => new CharacterSpellResponse()
                    {
                        Id = spell.Id,
                        Name = spell.Name,
                        Description = spell.Description,
                        Level = spell.Level,
                        CastingTime = new SpellCastingTimeResponse()
                        {
                            Value = spell.CastingTime?.Value ?? 0,
                            Type = spell.CastingTime?.Type ?? SpellCastingTimeType.Unspecified,
                            IsRitual = spell.CastingTime?.IsRitual ?? false,
                            Description = spell.CastingTime?.Description
                        },
                        Range = new SpellRangeResponse()
                        {
                            TargetValue = spell.Range?.TargetValue ?? 0,
                            TargetType = spell.Range?.TargetType ?? SpellRangeTargetType.Ranged,
                            EffectValue = spell.Range?.EffectValue ?? 0,
                            EffectType = spell.Range?.EffectType ?? SpellRangeEffectType.Target,
                        },
                        Components = new SpellComponentsResponse()
                        {
                            Verbal = spell.Components?.Verbal ?? false,
                            VerbalDescription = spell.Components?.VerbalDescription,
                            Somatic = spell.Components?.Somatic ?? false,
                            SomaticDescription = spell.Components?.SomaticDescription,
                            Material = spell.Components?.Material ?? false,
                            MaterialDescription = spell.Components?.MaterialDescription,
                        },
                        Duration = new SpellDurationResponse()
                        {
                            Value = spell.Duration?.Value ?? 0,
                            Type = spell.Duration?.Type ?? SpellDurationType.Unspecified,
                            Description = spell.Duration?.Description,
                        },
                        School = spell.School
                    }).ToList()
            };
        }

        public static CharacterSummaryResponse AsSummaryResponse(this Character character)
        {
            var experience = character.Attributes.GetByIdOrDefault("experience")?.CurrentValue ?? -1;
            var hitPointsAttribute = character.Attributes.GetByIdOrDefault("hitPoints");
            return new CharacterSummaryResponse
            {
                Id = character.Id.ToString(),
                Identifier = character.Identifier,
                Name = character.Name ?? "",
                CreatedDateTimeUtc = character.CreatedDateTimeUtc,
                UpdatedDateTimeUtc = character.UpdatedDateTimeUtc,
                Level = LevelHelper.GetLevel(experience),
                Experience = experience,
                PreviousLevelExperienceRequirement = LevelHelper.GetPreviousLevelExperienceRequirement(experience),
                NextLevelExperienceRequirement = LevelHelper.GetNextLevelExperienceRequirement(experience),
                CurrentHitPoints = hitPointsAttribute.CurrentValue,
                MaxHitPoints = hitPointsAttribute.DefaultValue,
                IsAlive = hitPointsAttribute.CurrentValue > 0,
                Backstory = character.Descriptions.GetByIdOrDefault("backstory")?.Value ?? "",
                PersonalityTraits = character.Descriptions.GetByIdOrDefault("personalityTraits")?.Value ?? "",
                Ideals = character.Descriptions.GetByIdOrDefault("ideals")?.Value ?? "",
                Bonds = character.Descriptions.GetByIdOrDefault("bonds")?.Value ?? "",
                Flaws = character.Descriptions.GetByIdOrDefault("flaws")?.Value ?? "",
                AlliesAndOrganisations = character.Descriptions.GetByIdOrDefault("alliesAndOrganisations")?.Value ?? "",
                Appearance = character.Descriptions.GetByIdOrDefault("appearance")?.Value ?? "",
            };
        }
    }
}