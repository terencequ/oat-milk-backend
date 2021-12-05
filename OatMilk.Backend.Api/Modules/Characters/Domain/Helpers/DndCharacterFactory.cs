using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using AutoMapper;
using Humanizer;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Shared.Domain.Helpers;
using OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction;
using OatMilk.Backend.Api.Modules.Shared.Identifier;
using OatMilk.Backend.Api.Modules.Spells.Domain.Models.Requests;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Helpers
{
    public class DndCharacterFactory
    {

        private const string Strength = "strength";
        private const string Dexterity = "dexterity";
        private const string Constitution = "constitution";
        private const string Intelligence = "intelligence";
        private const string Wisdom = "wisdom";
        private const string Charisma = "charisma";
        
        private readonly IMapper _mapper;
        private readonly Character _character;
        
        public DndCharacterFactory(IMapper mapper, Character character = null)
        {
            _mapper = mapper;
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
            var requests = new List<CharacterAbilityScoreRequest>(abilityScoreRequests ?? Array.Empty<CharacterAbilityScoreRequest>());
            void WithAbilityScore(string id)
            {
                if (requests.All(r => r.Id != id))
                {
                    requests.Add(new CharacterAbilityScoreRequest()
                    {
                        Id = id,
                        Name = id.Humanize(LetterCasing.Sentence),
                        Value = 10,
                        Proficient = false,
                        Expertise = false,
                    });
                }
            }

            // Create DnD requests if they don't exist
            WithAbilityScore(Strength);
            WithAbilityScore(Dexterity);
            WithAbilityScore(Constitution);
            WithAbilityScore(Intelligence);
            WithAbilityScore(Wisdom);
            WithAbilityScore(Charisma);

            _character.AbilityScores = _mapper.Map<List<CharacterAbilityScore>>(requests);
        }

        public void WithAbilityScoreProficiencies(IEnumerable<CharacterAbilityScoreProficiencyRequest> abilityScoreProficiencyRequests)
        {
            var requests = new List<CharacterAbilityScoreProficiencyRequest>(abilityScoreProficiencyRequests ?? Array.Empty<CharacterAbilityScoreProficiencyRequest>());
            void WithAbilityScoreProficiency(string id, string abilityScoreId)
            {
                if (requests.All(r => r.Id != id))
                {
                    requests.Add(new CharacterAbilityScoreProficiencyRequest()
                    {
                        AbilityScoreId = abilityScoreId,
                        Id = id,
                        Name = id.Humanize(LetterCasing.Sentence),
                        Proficient = false,
                        Expertise = false,
                    });
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

            // Check for any requests not relevant to any ability score
            var abilityScoreIds = _character.AbilityScores.Select(e => e.Id);
            var nonParentedRequests = requests
                .Where(r => !abilityScoreIds.Contains(r.AbilityScoreId))
                .ToList();
            if (nonParentedRequests.Any())
            {
                throw new ArgumentException(
                    $"There are ability score proficiencies in the request which do not relate to an existing ability score, " +
                    $"({JsonSerializer.Serialize(nonParentedRequests)})", nameof(CharacterRequest.AbilityScoreProficiencies));
            }
            
            foreach (var abilityScore in _character.AbilityScores)
            {
                var relevantRequests = requests
                    .Where(r => r.AbilityScoreId == abilityScore.Id)
                    .ToList();
                abilityScore.Proficiencies = _mapper.Map<List<CharacterAbilityScoreProficiency>>(relevantRequests);
            }
        }

        public void WithAttributes(IEnumerable<CharacterAttributeRequest> attributeRequests)
        {
            var requests = new List<CharacterAttributeRequest>(attributeRequests ?? Array.Empty<CharacterAttributeRequest>());
            void WithAttribute(string id, int defaultValue, int? currentValue = null)
            {
                if (requests.All(r => r.Id != id))
                {
                    requests.Add(new CharacterAttributeRequest()
                    {
                        Id = id,
                        Name = id.Humanize(LetterCasing.Sentence),
                        CurrentValue = currentValue ?? defaultValue,
                        DefaultValue = defaultValue
                    });
                }
            }
            
            WithAttribute("armorClass", 10);
            WithAttribute("speed", 30);
            WithAttribute("hitPoints", 10);
            WithAttribute("deathSaveSuccesses", 3, 0);
            WithAttribute("deathSaveFailures", 3, 0);
            WithAttribute("experience", 0, 0);
            
            _character.Attributes = _mapper.Map<List<CharacterAttribute>>(requests);
        }
        
        public void WithDescriptions(IEnumerable<CharacterDescriptionRequest> descriptionRequests)
        {
            var requests = new List<CharacterDescriptionRequest>(descriptionRequests ?? Array.Empty<CharacterDescriptionRequest>());
            void WithDescription(string id)
            {
                if (requests.All(r => r.Id != id))
                {
                    requests.Add(new CharacterDescriptionRequest()
                    {
                        Id = id,
                        Name = id.Humanize(LetterCasing.Sentence),
                        Value = null
                    });
                }
            }
            
            WithDescription("backstory");
            WithDescription("personalityTraits");
            WithDescription("ideals");
            WithDescription("bonds");
            WithDescription("flaws");
            WithDescription("alliesAndOrganisations");
            WithDescription("appearance");

            _character.Descriptions = _mapper.Map<List<CharacterDescription>>(requests);
        }

        public void WithSpells(IEnumerable<CharacterSpellRequest> spellRequests)
        {
            var requests = new List<CharacterSpellRequest>(spellRequests ?? Array.Empty<CharacterSpellRequest>());
            // All custom attributes
            _character.Spells = requests.Select(request => {
                var entity = _mapper.Map<CharacterSpell>(request);
                if (request.ShouldCreateNewId)
                {
                    entity.Id = RandomIdGenerator.GetBase36(requests, req => req.Id);
                }
                return entity;
            }).ToList();
        }
        
        public Character Build()
        {
            return _character;
        }
    }
}