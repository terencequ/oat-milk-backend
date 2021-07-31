using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MockQueryable.Moq;
using Moq;
using OatMilk.Backend.Api.Data.Entities.Abstraction;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.AutoMapper;
using OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.AutoMapper;

namespace OatMilk.Backend.Api.Tests.TestingHelpers
{
    /// <summary>
    /// Abstract class which can be inherited by test fixtures which need:
    /// - Configuration
    /// - Mapper
    /// - MockRepository
    /// </summary>
    /// <typeparam name="TEntity">Entity stored in the repository.</typeparam>
    public abstract class RepositoryFixture<TEntity> where TEntity : Entity
    {
        protected List<TEntity> Entities;
        protected readonly IConfiguration Configuration;
        protected readonly IMapper Mapper;
        protected readonly Mock<IRepository<TEntity>> MockRepository;

        protected RepositoryFixture(params TEntity[] entities)
        {
            Entities = entities.ToList();
            Configuration = new ConfigurationBuilder().AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("Auth:UserTokenSecret", "this is a test secret")
            }).Build();
            Mapper = TestAutoMapperHelper.GetAutoMapper();
            MockRepository = new Mock<IRepository<TEntity>>();
            MockRepository.Setup(m => m.GetQueryable())
                .Returns(Entities.AsQueryable().BuildMock().Object);
            MockRepository.Setup(m => m.GetByIdQueryable(It.IsAny<Guid>()))
                .Returns<Guid>(id => Entities.AsQueryable().BuildMock().Object.Where(e => e.Id == id));
            MockRepository.Setup(m => m.Add(It.IsAny<TEntity>()))
                .Callback<TEntity>(e =>
                {
                    e.Id = Guid.NewGuid();
                    Entities.Add(e);
                });
        }
        
        public Mock<IRepository<TEntity>> GetMockRepository()
        {
            return MockRepository;
        }
    }
}