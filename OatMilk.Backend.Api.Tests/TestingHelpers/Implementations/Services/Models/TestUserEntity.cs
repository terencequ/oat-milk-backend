using System;
using MongoDB.Bson;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models
{
    public class TestUserEntity : IUserEntity
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string Name { get; set; }
        public ObjectId UserId { get; set; }
        public string TestString { get; set; }
    }
}