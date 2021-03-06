using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Users.Data
{
    public class User : IAuditableEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
