using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Business.Mapping;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Characters.Data;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Helpers
{
    public class DndCharacterFactory
    {
        const string Strength = "strength";
        const string Dexterity = "dexterity";
        const string Constitution = "constitution";
        const string Intelligence = "intelligence";
        const string Wisdom = "wisdom";
        const string Charisma = "charisma";
        
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
        
        public void WithAbilityScores(ICollection<CharacterAbilityScoreRequest> abilityScoreRequests)
        {
            void WithAbilityScore(string id)
            {
                var existingRequest = abilityScoreRequests?.FirstOrDefault(r => r.Id == id);
                if (existingRequest != null)
                {
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
        }

        public void WithAbilityScoreProficiencies(ICollection<CharacterAbilityScoreProficiencyRequest> abilityScoreProficiencyRequests)
        {
            var character = _character ?? new Character();

            void WithAbilityScoreProficiency(string id, string abilityScoreId)
            {
                var existingRequest = abilityScoreProficiencyRequests?.FirstOrDefault(asp => asp.Id == id && asp.AbilityScoreId == abilityScoreId);
                if (existingRequest != null)
                {
                    character.AddOrUpdateAbilityScoreProficiency(id, abilityScoreId, existingRequest); // Override and replace
                }
                else
                {
                    character.AddOrUpdateAbilityScoreProficiency(id, abilityScoreId, null, true); // Create if doesn't exist (but don't override existing)
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
        }

        public void WithAttributes(ICollection<CharacterAttributeRequest> attributeRequests)
        {
            void WithAttribute(string id, int defaultValue, int? currentValue = null)
            {
                var existingRequest = attributeRequests?.FirstOrDefault(r => r.Id == id);
                if (existingRequest != null)
                {
                    _character.AddOrUpdateAttribute(id, defaultValue, currentValue); // Override and replace
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
        }
        
        public void WithDescriptions(ICollection<CharacterDescriptionRequest> descriptions)
        {
            void WithDescription(string id)
            {
                var existingRequest = descriptions?.FirstOrDefault(r => r.Id == id);
                if (existingRequest != null)
                {
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
        }

        public Character Build()
        {
            return _character;
        }
        
        public CharacterResponse BuildAsResponse()
        {
            return _character.AsResponse();
        }
    }
}