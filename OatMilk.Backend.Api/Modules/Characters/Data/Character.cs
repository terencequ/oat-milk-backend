using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;
using OatMilk.Backend.Api.Modules.Shared.Domain.Helpers;

namespace OatMilk.Backend.Api.Modules.Characters.Data
{
    public class Character : IUserEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public ObjectId UserId { get; set; }

        public List<CharacterAttribute> Attributes { get; set; } = new List<CharacterAttribute>();
        public List<CharacterAbilityScore> AbilityScores { get; set; } = new List<CharacterAbilityScore>();
        public List<CharacterDescription> Descriptions { get; set; } = new List<CharacterDescription>();
        public List<CharacterSpell> Spells { get; set; } = new List<CharacterSpell>();
    }
}