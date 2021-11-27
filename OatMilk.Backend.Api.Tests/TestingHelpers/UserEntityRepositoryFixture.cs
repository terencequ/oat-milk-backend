using System;
using System.Linq;
using MockQueryable.Moq;
using MongoDB.Bson;
using Moq;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Tests.TestingHelpers
{
    public class UserEntityRepositoryFixture<TEntity> : RepositoryFixture<TEntity> 
        where TEntity : class, IUserEntity
    {
        protected readonly ObjectId? UserId;
        protected Mock<IUserEntityRepository<TEntity>> MockUserRepository;
        
        public UserEntityRepositoryFixture(ObjectId? userId, params TEntity[] entities) : base(entities)
        {
            UserId = userId;
            MockUserRepository = new Mock<IUserEntityRepository<TEntity>>();
            MockUserRepository
                .Setup(m => m.Get())
                .Returns(entities.AsQueryable().BuildMock().Object.Where(e => e.UserId == userId));
            MockUserRepository
                .Setup(m => m.GetCurrentUserId())
                .Returns(UserId ?? throw new NullReferenceException());
            MockUserRepository
                .Setup(m => m.GetCurrentUserIdOrDefault())
                .Returns(UserId);
        }


    }
}