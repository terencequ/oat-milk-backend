using System;
using MongoDB.Bson;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models
{
    public class TestEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public string TestString { get; set; }
    }
}