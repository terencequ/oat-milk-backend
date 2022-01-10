using MongoDB.Bson;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models
{
    public class TestEntityResponse
    {
        public ObjectId Id { get; set; }
        public string TestString { get; set; }
    }
}