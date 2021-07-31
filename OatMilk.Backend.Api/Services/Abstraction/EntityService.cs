using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

            return await FindByIdAndMapToResponseAsync(entity.Id);
        }

        public async Task<TResponse> GetById(Guid id)
        {
            return await FindByIdAndMapToResponseAsync(id);
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
            
            return await FindByIdAndMapToResponseAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var entity = await FindByIdAsyncDetailed(id);

            Repository.Remove(entity);
            await Repository.SaveAsync();
        }
        
        #region Helpers

        protected async Task<TResponse> FindByIdAndMapToResponseAsync(Guid id)
        {
            var result = await Repository.GetByIdQueryable(id)
                .ProjectTo<TResponse>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            if (result == null)
            {
                throw new ArgumentException($"{typeof(TEntity).Name} could not be found with ID {id}!");
            }

            return result;
        }
        
        protected async Task<TEntity> FindByIdAsync(Guid id)
        {
            var entity = await Repository.GetQueryable().FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null)
            {
                throw new ArgumentException($"{nameof(TEntity)} with id '{id}' not found.", nameof(id));
            }

            return entity;
        }

        #endregion
    }
}