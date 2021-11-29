using System.Linq;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Helpers;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses;
using OatMilk.Backend.Api.Modules.Shared.Domain.Helpers;

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
                        CastingTime = spell.CastingTime,
                        RangeOrArea = spell.RangeOrArea,
                        Components = spell.Components,
                        Duration = spell.Duration,
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