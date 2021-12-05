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
                AbilityScores = character.AbilityScores,
                Attributes = character.Attributes,
                Descriptions = character.Descriptions,
                Spells = character.Spells
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