using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;
using OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Domain.Helpers;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Domain
{
    public abstract class ChildEntityService<TEntity, TEntityChild> : IChildEntityService<TEntityChild> 
        where TEntity : IEntity
        where TEntityChild : IChildEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public ChildEntityService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<TEntityChild>> GetAll(ObjectId entityId)
        {
            var entity = GetEntity(entityId);
            var result = GetChildrenNavigation(entity);
            return result;
        }

        public async Task SetAll(ObjectId entityId, ICollection<TEntityChild> newChildren)
        {
            var entity = GetEntity(entityId);
            var children = GetChildrenNavigation(entity);
            children.Clear();
            foreach (var newChild in newChildren)
            {
                children.Add(newChild);
            }
        }
        
        public async Task ClearAll(ObjectId entityId, ICollection<TEntityChild> newChildren)
        {
            var entity = GetEntity(entityId);
            var children = GetChildrenNavigation(entity);
            children.Clear();
        }
        
        public async Task<TEntityChild> Get(ObjectId entityId, string childId)
        {
            var entity = GetEntity(entityId);
            var children = GetChildrenNavigation(entity);
            return children.GetById(childId);
        }
        
        public async Task Add(ObjectId entityId, TEntityChild newChild)
        {
            var entity = GetEntity(entityId);
            var children = GetChildrenNavigation(entity);
            children.Add(newChild);
        }
        
        public async Task Update(ObjectId entityId, string childId, TEntityChild newChild)
        {
            var entity = GetEntity(entityId);
            var children = GetChildrenNavigation(entity);
            _mapper.Map(newChild, children.GetById(childId));
        }

        public async Task Delete(ObjectId entityId, string childId)
        {
            var entity = GetEntity(entityId);
            var children = GetChildrenNavigation(entity);
            var child = children.GetById(childId);
            children.Remove(child);
        }

        protected TEntity GetEntity(ObjectId entityId)
        {
            var entity = _repository.Get().FirstOrDefault(x => x.Id == entityId)
                         ?? throw new NullReferenceException($"{typeof(TEntity).Name} not found of id {entityId}");
            return entity;
        }
        
        protected abstract ICollection<TEntityChild> GetChildrenNavigation(TEntity entity);
    }
}