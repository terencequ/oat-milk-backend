using OatMilk.Backend.Api.Services.Models.Abstraction;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models
{
    public class TestUserEntityRequest : INamedRequest
    {
        public string Name { get; set; }
        public string TestString { get; set; }
    }
}