using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Data
{
    public class Character : IUserEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string Name { get; set; }
        public ObjectId UserId { get; set; }

        public List<CharacterAttribute> Attributes { get; set; } = new List<CharacterAttribute>();
        public List<CharacterAbilityScore> AbilityScores { get; set; } = new List<CharacterAbilityScore>();
        public List<CharacterDescription> Descriptions { get; set; } = new List<CharacterDescription>();

        #region Attribute

        public CharacterAttribute GetAttributeOrDefault(string id)
        {
            return Attributes.FirstOrDefault(attribute => attribute.Id == id);
        }
        
        /// <summary>
        /// Overload for <see cref="AddOrUpdateAttribute(string,CharacterAttributeRequest,bool)"/>.
        /// </summary>
        public void AddOrUpdateAttribute(string id, int defaultValue, int? currentValue = null, bool dontOverride = false)
        {
            AddOrUpdateAttribute(id, new CharacterAttributeRequest()
            {
                Name = id.Humanize(LetterCasing.Sentence),
                CurrentValue = currentValue ?? defaultValue,
                DefaultValue = defaultValue
            }, dontOverride);
        }
        
        /// <summary>
        /// Add or update an ability score. If ID matches, it will update existing ability score,
        /// otherwise create a new ability score.
        /// </summary>
        public void AddOrUpdateAttribute(string id, CharacterAttributeRequest request = null, bool dontOverride = false)
        {
            // Make default
            request ??= new CharacterAttributeRequest()
            {
                Name = id.Humanize(LetterCasing.Sentence), 
                CurrentValue = 0,
                DefaultValue = 0
            };
            
            var attribute = Attributes.FirstOrDefault(s => s.Id == id);
            if (attribute == null)
            {
                attribute = new CharacterAttribute();
                Attributes.Add(attribute);
            } else if (dontOverride)
            {
                return;
            }
            
            attribute.Id = id;
            attribute.Name = request.Name;
            attribute.CurrentValue = request.CurrentValue;
            attribute.DefaultValue = request.DefaultValue;
        }

        public void RemoveAttribute(string id)
        {
            var attribute = Attributes?.FirstOrDefault(s => s.Id == id);
            if(attribute != null)
            {
                Attributes.Remove(attribute);
            }
        }

        #endregion
        
        #region Ability Score

        public CharacterAbilityScore GetAbilityScoreOrDefault(string id)
        {
            return AbilityScores.FirstOrDefault(abilityScore => abilityScore.Id == id);
        }
        
        public bool AbilityScoreExists(string id)
        {
            return AbilityScores.Any(s => s.Id == id);
        }
        
        /// <summary>
        /// Add or update an ability score. If ID matches, it will update existing ability score,
        /// otherwise create a new ability score.
        /// </summary>
        public void AddOrUpdateAbilityScore(string id, CharacterAbilityScoreRequest request = null, bool dontOverride = false)
        {
            // Make default
            request ??= new CharacterAbilityScoreRequest()
            {
                Name = id.Humanize(LetterCasing.Sentence),
                Value = 10,
                Proficient = false,
                Expertise = false,
            };
            
            // Find existing ability score
            var abilityScore = AbilityScores.FirstOrDefault(s => s.Id == id);
            if (abilityScore == null)
            {
                abilityScore = new CharacterAbilityScore();
                AbilityScores.Add(abilityScore);
            } else if (dontOverride)
            {
                return;
            }
            
            abilityScore.Id = id;
            abilityScore.Name = request.Name;
            abilityScore.Value = request.Value;
            abilityScore.Proficient = request.Proficient;
            abilityScore.Expertise = request.Expertise;
        }

        public void RemoveAbilityScore(string id)
        {
            var abilityScore = AbilityScores?.FirstOrDefault(s => s.Id == id);
            if(abilityScore != null)
            {
                AbilityScores.Remove(abilityScore);
            }
        }

        #endregion

        #region Ability Score Proficiency

        public CharacterAbilityScoreProficiency GetAbilityScoreProficiencyOrDefault(string id, string abilityScoreId)
        {
            // Find parent
            var abilityScore = AbilityScores.FirstOrDefault(s => s.Id == abilityScoreId) 
                               ?? throw new NullReferenceException($"Ability score not found {abilityScoreId}");
            return abilityScore.Proficiencies.FirstOrDefault(proficiency => proficiency.Id == id);
        }
        
        public bool AbilityScoreProficiencyExists(string id, string abilityScoreId)
        {
            // Find parent
            var abilityScore = AbilityScores.FirstOrDefault(s => s.Id == abilityScoreId) 
                               ?? throw new NullReferenceException($"Ability score not found {abilityScoreId}");
            return abilityScore.Proficiencies.Any(s => s.Id == id);
        }

        /// <summary>
        /// Add or update an ability score proficiency. If ability score ID and proficiency ID matches,
        /// it will update existing ability score proficiency, otherwise create a new ability score proficiency.
        /// </summary>
        /// <param name="id">Ability score ID</param>
        /// <param name="abilityScoreId">This will override the ability score ID in request if not null.</param>
        /// <param name="request">Ability score ID here will be overridden if abilityScoreId is not null.</param>
        /// <param name="dontOverride">If this is true, this function will do nothing if an AbilityScoreProficiency already exists.</param>
        public void AddOrUpdateAbilityScoreProficiency(string id, 
            string abilityScoreId = null,
            CharacterAbilityScoreProficiencyRequest request = null, 
            bool dontOverride = false)
        {
            // Make default
            request ??= new CharacterAbilityScoreProficiencyRequest()
            {
                Name = id.Humanize(LetterCasing.Sentence),
                Proficient = false,
                Expertise = false,
            };
            request.AbilityScoreId ??= abilityScoreId;
            
            // Find parent
            var abilityScore = AbilityScores.FirstOrDefault(s => s.Id == request.AbilityScoreId) 
                               ?? throw new NullReferenceException($"Ability score not found {request.AbilityScoreId}");

            // Find existing proficiency
            var proficiency = abilityScore.Proficiencies.FirstOrDefault(p => p.Id == id);
            if (proficiency == null)
            {
                proficiency = new CharacterAbilityScoreProficiency();
                abilityScore.Proficiencies.Add(proficiency);
            } else if (dontOverride)
            {
                return;
            }
            
            proficiency.Id = id;
            proficiency.Name = request.Name;
            proficiency.Proficient = request.Proficient;
            proficiency.Expertise = request.Expertise;
        }
        
        public void RemoveAbilityScoreProficiency(string abilityScoreId, string id)
        {
            var abilityScore = AbilityScores.FirstOrDefault(s => s.Id == abilityScoreId) 
                               ?? throw new NullReferenceException($"Ability score not found {abilityScoreId}");
            
            var proficiency = abilityScore.Proficiencies.FirstOrDefault(p => p.Id == id);
            if (proficiency != null)
            {
                abilityScore.Proficiencies.Remove(proficiency);
            }
        }

        #endregion

        #region Descriptions

        public CharacterDescription GetDescriptionOrDefault(string id)
        {
            return Descriptions.FirstOrDefault(description => description.Id == id);
        }
        
        public bool DescriptionExists(string id)
        {
            return Descriptions.Any(s => s.Id == id);
        }
        
        /// <summary>
        /// Add or update a description. If ID matches, it will update existing description,
        /// otherwise create a new description.
        /// </summary>
        public void AddOrUpdateDescription(string id, CharacterDescriptionRequest request = null, bool dontOverride = false)
        {
            // Make default
            request ??= new CharacterDescriptionRequest()
            {
                Name = id.Humanize(LetterCasing.Sentence),
                Value = null,
            };
            
            var description = Descriptions.FirstOrDefault(s => s.Id == id);
            if (description == null)
            {
                description = new CharacterDescription();
                Descriptions.Add(description);
            } else if (dontOverride)
            {
                return;
            }
            
            description.Id = id;
            description.Name = request.Name;
            description.Value = request.Value;
        }

        public void RemoveDescription(string id)
        {
            var description = Descriptions?.FirstOrDefault(s => s.Id == id);
            if(description != null)
            {
                Descriptions.Remove(description);
            }
        }

        #endregion
    }
}