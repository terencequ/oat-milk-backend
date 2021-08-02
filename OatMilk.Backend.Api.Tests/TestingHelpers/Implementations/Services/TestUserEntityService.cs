﻿using AutoMapper;
using OatMilk.Backend.Api.Data.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.Models;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services
{
    public class TestUserEntityService : UserEntityService<TestUserEntityRequest, TestUserEntity, TestUserEntityResponse>
    {
        public TestUserEntityService(IRepository<TestUserEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}