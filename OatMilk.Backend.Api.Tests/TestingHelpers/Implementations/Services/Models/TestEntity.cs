using System;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models
{
    public class TestEntity : IEntity
    {
        public Guid Id { get; set; }
        public string TestString { get; set; }
    }
}