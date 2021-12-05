using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Humanizer;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Shared.Domain.Helpers;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Helpers
{
    /// <summary>
    /// Class which contains a helper function to create the skeleton of a DnD character.
    /// </summary>
    public static class DndCharacterCreator
    {
        private const string Strength = "strength";
        private const string Dexterity = "dexterity";
        private const string Constitution = "constitution";
        private const string Intelligence = "intelligence";
        private const string Wisdom = "wisdom";
        private const string Charisma = "charisma";

        public static Character CreateDndCharacter(CharacterRequest request)
        {
            var character = new Character()
            {
                Name = request.Name,
            };
            
            character.WithAbilityScore(Strength);
            character.WithAbilityScore(Dexterity);
            character.WithAbilityScore(Constitution);
            character.WithAbilityScore(Intelligence);
            character.WithAbilityScore(Wisdom);
            character.WithAbilityScore(Charisma);
            
            character.WithAbilityScoreProficiency("acrobatics", Dexterity);
            character.WithAbilityScoreProficiency("animalHandling", Wisdom);
            character.WithAbilityScoreProficiency("arcana", Intelligence);
            character.WithAbilityScoreProficiency("athletics", Strength);
            character.WithAbilityScoreProficiency("deception", Charisma);
            character.WithAbilityScoreProficiency("history", Intelligence);
            character.WithAbilityScoreProficiency("insight", Wisdom);
            character.WithAbilityScoreProficiency("intimidation", Charisma);
            character.WithAbilityScoreProficiency("investigation", Intelligence);
            character.WithAbilityScoreProficiency("medicine", Wisdom);
            character.WithAbilityScoreProficiency("nature", Intelligence);
            character.WithAbilityScoreProficiency("perception", Wisdom);
            character.WithAbilityScoreProficiency("performance", Charisma);
            character.WithAbilityScoreProficiency("persuasion", Charisma);
            character.WithAbilityScoreProficiency("religion", Intelligence);
            character.WithAbilityScoreProficiency("sleightOfHand", Dexterity);
            character.WithAbilityScoreProficiency("stealth", Dexterity);
            character.WithAbilityScoreProficiency("survival", Wisdom);
            
            character.WithAttribute("armorClass", 10);
            character.WithAttribute("speed", 30);
            character.WithAttribute("hitPoints", 10);
            character.WithAttribute("deathSaveSuccesses", 3, 0);
            character.WithAttribute("deathSaveFailures", 3, 0);
            character.WithAttribute("experience", 0, 0);
            
            character.WithDescription("backstory");
            character.WithDescription("personalityTraits");
            character.WithDescription("ideals");
            character.WithDescription("bonds");
            character.WithDescription("flaws");
            character.WithDescription("alliesAndOrganisations");
            character.WithDescription("appearance");
            
            return character;
        }
        
        private static void WithAbilityScore(this Character character, string abilityId)
        {
            var abilityScore = new CharacterAbilityScore()
            {
                Id = abilityId,
                Name = abilityId.Humanize(LetterCasing.Sentence),
                Value = 10,
                Proficient = false,
                Expertise = false,
            };
            character.AbilityScores.Add(abilityScore);
        }
        
        private static void WithAbilityScoreProficiency(this Character character, string id, string abilityScoreId)
        {
            var abilityScoreProficiency = new CharacterAbilityScoreProficiency()
            {
                Id = id,
                Name = id.Humanize(LetterCasing.Sentence),
                Proficient = false,
                Expertise = false,
            };
            var abilityScore = character.AbilityScores.GetById(abilityScoreId);
            abilityScore.Proficiencies.Add(abilityScoreProficiency);
        }

        private static void WithAttribute(this Character character, string id, int defaultValue, int? currentValue = null)
        {
            var attribute = new CharacterAttribute()
            {
                Id = id,
                Name = id.Humanize(LetterCasing.Sentence),
                CurrentValue = currentValue ?? defaultValue,
                DefaultValue = defaultValue
            };
            character.Attributes.Add(attribute);
        }
        
        private static void WithDescription(this Character character, string id)
        {
            var description = new CharacterDescription()
            {
                Id = id,
                Name = id.Humanize(LetterCasing.Sentence),
                Value = null
            };
            character.Descriptions.Add(description);
        }
    }
}