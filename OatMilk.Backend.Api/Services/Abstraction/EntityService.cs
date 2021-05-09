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
            await Repository.SaveAsync();

            return Mapper.Map<TResponse>(entity);
        }

        public async Task<TResponse> GetById(Guid id)
        {
            var entity = await FindByIdAsync(id);
            return Mapper.Map<TResponse>(entity);
        }

        public async Task<TResponse> Update(Guid id, TRequest request)
        {
            var entity = await FindByIdAsync(id);
            Mapper.Map(request, entity);
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

        protected async Task<TEntity> FindByIdAsync(Guid id)
        {
            var effect = await Repository.Get().FirstOrDefaultAsync(a => a.Id == id);
            if (effect == null)
            {
                throw new ArgumentException($"Ability with id '{id}' not found.", nameof(id));
            }

            return effect;
        }

        #endregion
    }
}