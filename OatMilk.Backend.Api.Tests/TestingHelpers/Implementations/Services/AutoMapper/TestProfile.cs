using AutoMapper;
using OatMilk.Backend.Api.Tests.TestingHelpers.Models;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.AutoMapper
{
    public class TestProfile : Profile
    {
        public TestProfile() : base()
        {
            CreateMap<TestEntityRequest, TestEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<TestEntity, TestEntityResponse>();
        }
    }
}