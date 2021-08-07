using System.Collections.Generic;
using System.Linq;
using Humanizer;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Data;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Helpers
{
    public class DndCharacterFactory
    {
        private const string Strength = "strength";
        private const string Dexterity = "dexterity";
        private const string Constitution = "constitution";
        private const string Intelligence = "intelligence";
        private const string Wisdom = "wisdom";
        private const string Charisma = "charisma";
        
        private Character _character;
        
        public DndCharacterFactory(Character character = null)
        {
            _character = character ?? new Character();
        }

        public void WithId(ObjectId id)
        {
            _character.Id = id;
        }
        
        public void WithName(string name)
        {
            _character.Name = name;
        }
        
        public void WithAbilityScores(IEnumerable<CharacterAbilityScoreRequest> abilityScoreRequests)
        {
            var requests = new List<CharacterAbilityScoreRequest>(abilityScoreRequests);
            void WithAbilityScore(string id, bool generateName = true)
            {
                var existingRequest = requests?.FirstOrDefault(r => r.Id == id);
                if (existingRequest != null)
                {
                    requests.Remove(existingRequest);
                    if (generateName)
                    {
                        existingRequest.Name = id.Humanize(LetterCasing.Sentence);
                    }
                    _character.AddOrUpdateAbilityScore(id, existingRequest); // Override and replace
                }
                else
                {
                    _character.AddOrUpdateAbilityScore(id, null, true); // Create if doesn't exist (but don't override existing)
                }
            }

            // Create DnD properties if they don't exist in character, override if exist in requests
            WithAbilityScore(Strength);
            WithAbilityScore(Dexterity);
            WithAbilityScore(Constitution);
            WithAbilityScore(Intelligence);
            WithAbilityScore(Wisdom);
            WithAbilityScore(Charisma);

            // All custom attributes
            var customRequests = new List<CharacterAbilityScoreRequest>(requests);
            foreach (var request in customRequests)
            {
                WithAbilityScore(request.Id, false);
            }
        }

        public void WithAbilityScoreProficiencies(IEnumerable<CharacterAbilityScoreProficiencyRequest> abilityScoreProficiencyRequests)
        {
            var requests = new List<CharacterAbilityScoreProficiencyRequest>(abilityScoreProficiencyRequests);
            void WithAbilityScoreProficiency(string id, string abilityScoreId, bool generateName = true)
            {
                var existingRequest = requests?.FirstOrDefault(asp => asp.Id == id && asp.AbilityScoreId == abilityScoreId);
                if (existingRequest != null)
                {
                    requests.Remove(existingRequest);
                    if (generateName)
                    {
                        existingRequest.Name = id.Humanize(LetterCasing.Sentence);
                    }
                    existingRequest.Name = id.Humanize(LetterCasing.Sentence);
                    _character.AddOrUpdateAbilityScoreProficiency(id, abilityScoreId, existingRequest); // Override and replace
                }
                else
                {
                    _character.AddOrUpdateAbilityScoreProficiency(id, abilityScoreId, null, true); // Create if doesn't exist (but don't override existing)
                }
            }
            
            WithAbilityScoreProficiency("acrobatics", Dexterity);
            WithAbilityScoreProficiency("animalHandling", Wisdom);
            WithAbilityScoreProficiency("arcana", Intelligence);
            WithAbilityScoreProficiency("athletics", Strength);
            WithAbilityScoreProficiency("deception", Charisma);
            WithAbilityScoreProficiency("history", Intelligence);
            WithAbilityScoreProficiency("insight", Wisdom);
            WithAbilityScoreProficiency("intimidation", Charisma);
            WithAbilityScoreProficiency("investigation", Intelligence);
            WithAbilityScoreProficiency("medicine", Wisdom);
            WithAbilityScoreProficiency("nature", Intelligence);
            WithAbilityScoreProficiency("perception", Wisdom);
            WithAbilityScoreProficiency("performance", Charisma);
            WithAbilityScoreProficiency("persuasion", Charisma);
            WithAbilityScoreProficiency("religion", Intelligence);
            WithAbilityScoreProficiency("sleightOfHand", Dexterity);
            WithAbilityScoreProficiency("stealth", Dexterity);
            WithAbilityScoreProficiency("survival", Wisdom);
            
            // All custom attributes
            var customRequests = new List<CharacterAbilityScoreProficiencyRequest>(requests);
            foreach (var request in customRequests)
            {
                WithAbilityScoreProficiency(request.Id, request.AbilityScoreId, false);
            }
        }

        public void WithAttributes(IEnumerable<CharacterAttributeRequest> attributeRequests)
        {
            var requests = new List<CharacterAttributeRequest>(attributeRequests);
            void WithAttribute(string id, int defaultValue, int? currentValue = null, bool generateName = true)
            {
                var existingRequest = requests?.FirstOrDefault(r => r.Id == id);
                if (existingRequest != null)
                {
                    requests.Remove(existingRequest);
                    if (generateName)
                    {
                        existingRequest.Name = id.Humanize(LetterCasing.Sentence);
                    }
                    existingRequest.Name = id.Humanize(LetterCasing.Sentence);
                    _character.AddOrUpdateAttribute(id, existingRequest); // Override and replace
                }
                else
                {
                    _character.AddOrUpdateAttribute(id, defaultValue, currentValue, true); // Create if doesn't exist (but don't override existing)
                }
            }
            
            WithAttribute("armorClass", 10);
            WithAttribute("speed", 30);
            WithAttribute("hitPoints", 10);
            WithAttribute("deathSaveSuccesses", 3, 0);
            WithAttribute("deathSaveFailures", 3, 0);
            WithAttribute("experience", 0, 0);
            
            // All custom attributes
            var customRequests = new List<CharacterAttributeRequest>(requests);
            foreach (var request in customRequests)
            {
                WithAttribute(request.Id, request.DefaultValue, request.CurrentValue, false);
            }
        }
        
        public void WithDescriptions(IEnumerable<CharacterDescriptionRequest> descriptionRequests)
        {
            var requests = new List<CharacterDescriptionRequest>(descriptionRequests);
            void WithDescription(string id, bool generateName = true)
            {
                var existingRequest = requests?.FirstOrDefault(r => r.Id == id);
                if (existingRequest != null)
                {
                    requests.Remove(existingRequest);
                    if (generateName)
                    {
                        existingRequest.Name = id.Humanize(LetterCasing.Sentence);
                    }
                    _character.AddOrUpdateDescription(id, existingRequest); // Override and replace
                }
                else
                {
                    _character.AddOrUpdateDescription(id, null, true); // Create if doesn't exist (but don't override existing)
                }
            }
            
            WithDescription("personalityTraits");
            WithDescription("ideals");
            WithDescription("bonds");
            WithDescription("flaws");
            WithDescription("alliesAndOrganisations");
            WithDescription("appearance");
            
            // All custom attributes
            var customRequests = new List<CharacterDescriptionRequest>(requests);
            foreach (var request in customRequests)
            {
                WithDescription(request.Id, false);
            }
        }

        public Character Build()
        {
            return _character;
        }
    }
}