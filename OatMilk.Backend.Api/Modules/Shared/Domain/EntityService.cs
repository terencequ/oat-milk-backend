using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;
using OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Domain
{
    /// <summary>
    /// Base service class for manipulating entities.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class EntityService<TRequest, TEntity, TResponse> : IEntityService<TRequest, TResponse>
        where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        public EntityService(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<TResponse> CreateAsync(TRequest request)
        {
            var entity = Mapper.Map<TEntity>(request);
            if (entity is IAuditableEntity auditableEntity)
            {
                auditableEntity.CreatedDateTimeUtc = DateTime.UtcNow;
                auditableEntity.UpdatedDateTimeUtc = DateTime.UtcNow;
            }
            await Repository.AddAsync(entity);

            return Mapper.Map<TResponse>(entity);
        }

        public virtual Task<TResponse> GetByIdAsync(ObjectId id)
        {
            var entity = FindById(id);
            return Task.FromResult(Mapper.Map<TResponse>(entity));
        }

        public virtual async Task<TResponse> UpdateAsync(ObjectId id, TRequest request)
        {
            var entity = FindById(id);
            Mapper.Map(request, entity);
            if (entity is IAuditableEntity auditableEntity)
            {
                auditableEntity.UpdatedDateTimeUtc = DateTime.UtcNow;
            }

            await Repository.UpdateAsync(entity);

            return Mapper.Map<TResponse>(entity);
        }

        public virtual async Task DeleteAsync(ObjectId id)
        {
            var entity = FindById(id);

            await Repository.RemoveAsync(entity);
        }
        
        #region Helpers

        protected TEntity FindById(ObjectId id)
        {
            var entity = Repository.Get().FirstOrDefault(a => a.Id == id);
            if (entity == null)
            {
                throw new ArgumentException($"{nameof(TEntity)} with id '{id}' not found.", nameof(id));
            }

            return entity;
        }

        #endregion
    }
}