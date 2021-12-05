using AutoMapper;
using OatMilk.Backend.Api.Modules.Shared.Domain;
using OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services
{
    public class TestEntityService : EntityService<TestEntityRequest, TestEntity, TestEntityResponse>
    {
        public TestEntityService(IRepository<TestEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}