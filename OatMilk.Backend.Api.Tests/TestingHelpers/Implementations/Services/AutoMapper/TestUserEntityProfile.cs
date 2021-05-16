using AutoMapper;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.AutoMapper
{
    public class TestUserEntityProfile : Profile
    {
        public TestUserEntityProfile() : base()
        {
            CreateMap<TestUserEntityRequest, TestUserEntity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<TestUserEntity, TestUserEntityResponse>();
        }
    }
}