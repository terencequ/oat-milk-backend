using System;
using System.Collections.Generic;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Shared.Business.Models.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests
{
    public class CharacterRequest : INamedRequest
    {
        public string Name { get; set; }
        public List<CharacterAttributeRequest> Attributes { get; set; }
        public List<CharacterAbilityScoreRequest> AbilityScores { get; set; }
        public List<CharacterAbilityScoreProficiencyRequest> AbilityScoreProficiencies { get; set; }
        public List<CharacterDescriptionRequest> Descriptions { get; set; }
    }

    public class CharacterAttributeRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CurrentValue { get; set; }
        public int DefaultValue { get; set; }
    }
    
    public class CharacterDescriptionRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class CharacterAbilityScoreRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
    }

    public class CharacterAbilityScoreProficiencyRequest
    {
        public string AbilityScoreId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Proficient { get; set; }
        public bool Expertise { get; set; }
    }
}