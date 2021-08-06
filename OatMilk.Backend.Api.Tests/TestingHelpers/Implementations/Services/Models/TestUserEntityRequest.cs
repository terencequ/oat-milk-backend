using OatMilk.Backend.Api.Modules.Shared.Business.Models.Abstraction;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models
{
    public class TestUserEntityRequest : INamedRequest
    {
        public string Name { get; set; }
        public string TestString { get; set; }
    }
}