using System.Linq;
using OatMilk.Backend.Api.Modules.Characters.Business.Helpers;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Characters.Data;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Mapping
{
    public static class CharacterMappingExtensions
    {
        public static CharacterResponse AsResponse(this Character character)
        {
            var experience = character.GetAttributeOrDefault("experience")?.CurrentValue ?? -1;
            return new CharacterResponse()
            {
                Id = character.Id.ToString(),
                Identifier = character.Identifier,
                Name = character.Name,
                CreatedDateTimeUtc = character.CreatedDateTimeUtc,
                UpdatedDateTimeUtc = character.UpdatedDateTimeUtc,
                Level = new CharacterLevelResponse()
                {
                    Level = LevelHelper.GetLevel(experience),
                    Experience = experience,
                    PreviousLevelExperienceRequirement = LevelHelper.GetPreviousLevelExperienceRequirement(experience),
                    NextLevelExperienceRequirement = LevelHelper.GetNextLevelExperienceRequirement(experience),
                },
                AbilityScores = character.AbilityScores
                    .Select(abilityScore => new CharacterAbilityScoreResponse()
                    {
                        Id = abilityScore.Id,
                        Name = abilityScore.Name,
                        Value = abilityScore.Value,
                        Expertise = abilityScore.Expertise,
                        Proficient = abilityScore.Proficient,
                        Proficiencies = abilityScore.Proficiencies
                            .Select(proficiency => new CharacterAbilityScoreProficiencyResponse()
                            {
                                Id = proficiency.Id,
                                Name = proficiency.Name,
                                Expertise = proficiency.Expertise,
                                Proficient = proficiency.Proficient
                            }).ToList()
                    }).ToList(),
                Attributes = character.Attributes
                    .Select(attribute => new CharacterAttributeResponse()
                    {
                        Id = attribute.Id,
                        Name = attribute.Name,
                        CurrentValue = attribute.CurrentValue,
                        DefaultValue = attribute.DefaultValue
                    }).ToList(),
                Descriptions = character.Descriptions
                    .Select(description => new CharacterDescriptionResponse()
                    {
                        Id = description.Id,
                        Name = description.Name,
                        Value = description.Value
                    }).ToList()
            };
        }

        public static CharacterSummaryResponse AsSummaryResponse(this Character character)
        {
            var experience = character.GetAttributeOrDefault("experience")?.CurrentValue ?? -1;
            return new CharacterSummaryResponse
            {
                Id = character.Id.ToString(),
                Identifier = character.Identifier,
                Name = character.Name,
                Classes = "not implemented yet",
                CreatedDateTimeUtc = character.CreatedDateTimeUtc,
                UpdatedDateTimeUtc = character.UpdatedDateTimeUtc,
                Level = LevelHelper.GetLevel(experience),
                Experience = experience,
                PreviousLevelExperienceRequirement = LevelHelper.GetPreviousLevelExperienceRequirement(experience),
                NextLevelExperienceRequirement = LevelHelper.GetNextLevelExperienceRequirement(experience),
                IsAlive = character.GetAttributeOrDefault("hitPoints").CurrentValue > 0,
            };
        }
    }
}