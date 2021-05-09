using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Entities.Abstraction;
using OatMilk.Backend.Api.Repositories.Abstraction.Interface;
using OatMilk.Backend.Api.Services.Abstraction.Interface;
using OatMilk.Backend.Api.Services.Models.Abstraction;

namespace OatMilk.Backend.Api.Services.Abstraction.Abstract
{
    public abstract class UserEntityService<TRequest, TEntity, TResponse> : EntityService<TRequest, TEntity, TResponse>, IUserEntityService<TRequest, TResponse>
        where TRequest : NamedRequest
        where TEntity : UserEntity
    {
        protected UserEntityService(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        
        public new async Task<TResponse> Create(TRequest request)
        {
            // Check for duplicate name
            if (Repository.Get().Any(a => a.Name == request.Name))
            {
                throw new ArgumentException($"Ability of name '{request.Name}' already exists!", nameof(request.Name));
            }
            return await base.Create(request);
        }
        
        public async Task<TResponse> GetByName(string name)
        {
            var effect = await FindEffectByNameAsync(name);
            return Mapper.Map<TResponse>(effect);
        }
        
        #region Helpers

        private async Task<TEntity> FindEffectByNameAsync(string name)
        {
            var entity = await Repository.Get().FirstOrDefaultAsync(a => a.Name == name);
            if (entity == null)
            {
                throw new ArgumentException($"Ability with name '{name}' not found.", nameof(name));
            }

            return entity;
        }
        
        #endregion
    }
}