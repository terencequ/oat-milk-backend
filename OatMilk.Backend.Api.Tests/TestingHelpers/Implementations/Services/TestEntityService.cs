using AutoMapper;
using OatMilk.Backend.Api.Repositories.Abstraction.Interface;
using OatMilk.Backend.Api.Services.Abstraction.Abstract;
using OatMilk.Backend.Api.Tests.TestingHelpers.Models;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services
{
    public class TestEntityService : EntityService<TestEntityRequest, TestEntity, TestEntityResponse>
    {
        public TestEntityService(IRepository<TestEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}