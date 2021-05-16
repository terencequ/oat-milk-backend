using AutoMapper;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.AutoMapper
{
    public class TestEntityProfile : Profile
    {
        public TestEntityProfile() : base()
        {
            CreateMap<TestEntityRequest, TestEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<TestEntity, TestEntityResponse>();
        }
    }
}