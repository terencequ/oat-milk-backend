using OatMilk.Backend.Api.Services.Models.Abstraction;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models
{
    public class TestUserEntityRequest : NamedRequest
    {
        public string TestString { get; set; }
    }
}