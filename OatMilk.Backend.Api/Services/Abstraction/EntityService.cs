using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Entities.Abstraction;
using OatMilk.Backend.Api.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public abstract class EntityService<TRequest, TEntity, TResponse> : IEntityService<TRequest, TResponse>
        where TEntity : Entity
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        protected EntityService(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<TResponse> Create(TRequest request)
        {
            // Create ability and add it to database
            var entity = Mapper.Map<TEntity>(request);
            Repository.Add(entity);
            if (entity is AuditableEntity auditableEntity)
            {
                auditableEntity.CreatedDateTimeUtc = DateTime.UtcNow;
                auditableEntity.UpdatedDateTimeUtc = DateTime.UtcNow;
            }
            await Repository.SaveAsync();

            return Mapper.Map<TResponse>(entity);
        }

        public async Task<TResponse> GetById(Guid id)
        {
            var entity = await FindByIdAsyncDetailed(id);
            return Mapper.Map<TResponse>(entity);
        }

        public async Task<TResponse> Update(Guid id, TRequest request)
        {
            var entity = await FindByIdAsync(id);
            Mapper.Map(request, entity);
            if (entity is AuditableEntity auditableEntity)
            {
                auditableEntity.UpdatedDateTimeUtc = DateTime.UtcNow;
            }
            await Repository.SaveAsync();
            
            return Mapper.Map<TResponse>(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await FindByIdAsync(id);

            Repository.Remove(entity);
            await Repository.SaveAsync();
        }
        
        #region Helpers

        protected async Task<TEntity> FindByIdAsyncDetailed(Guid id)
        {
            var entity = await Repository.GetWithIncludes().FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null)
            {
                throw new ArgumentException($"{nameof(TEntity)} with id '{id}' not found.", nameof(id));
            }

            return entity;
        }
        
        protected async Task<TEntity> FindByIdAsync(Guid id)
        {
            var entity = await Repository.Get().FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null)
            {
                throw new ArgumentException($"{nameof(TEntity)} with id '{id}' not found.", nameof(id));
            }

            return entity;
        }

        #endregion
    }
}