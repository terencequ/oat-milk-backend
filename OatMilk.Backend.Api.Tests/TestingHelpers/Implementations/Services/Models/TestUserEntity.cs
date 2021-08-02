using System;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models
{
    public class TestUserEntity : IUserEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string TestString { get; set; }
    }
}