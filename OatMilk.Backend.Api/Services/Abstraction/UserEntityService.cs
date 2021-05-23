using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Entities.Abstraction;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Models.Abstraction;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services.Abstraction
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
            ThrowIfNameExists(request.Name);
            return await base.Create(request);
        }

        public async Task<PageResponse<TResponse>> GetMultiple(SearchableSortedPageFilter filter)
        {
            var query = Repository
                .Get();

            // Search by name
            if (filter.SearchByName != null)
            {
                query = query.Where(ability => ability.Name.Contains(filter.SearchByName));
            }

            // Sorting
            var sortAscending = filter.SortAscending ?? false; // By default, should sort by descending order
            switch (filter.SortColumnName?.ToLower())
            {
                case "name":
                    query = sortAscending
                        ? query.OrderBy(ability => ability.Name)
                        : query.OrderByDescending(ability => ability.Name);
                    break;
                case null: // No filter means sort it by createddatetime
                case "createddatetimeutc":
                    query = sortAscending
                        ? query.OrderBy(ability => ability.CreatedDateTimeUtc)
                        : query.OrderByDescending(ability => ability.CreatedDateTimeUtc);
                    break;
                case "updateddatetimeutc":
                    query = sortAscending
                        ? query.OrderBy(ability => ability.UpdatedDateTimeUtc)
                        : query.OrderByDescending(ability => ability.UpdatedDateTimeUtc);
                    break;
                default:
                    throw new ArgumentException(
                        $"Cannot sort by {filter.SortColumnName}, because the column doesn't exist!",
                        nameof(filter.SortColumnName));
            }
            
            return await query
                .ProjectTo<TResponse>(Mapper.ConfigurationProvider)
                .GetPageResponseAsync(filter);
        }

        public async Task<TResponse> GetByName(string name)
        {
            var effect = await FindByNameAsyncDetailed(name);
            return Mapper.Map<TResponse>(effect);
        }
        
        #region Helpers

        protected void ThrowIfNameExists(string name)
        {
            // Check for duplicate name
            if (Repository.Get().Any(a => a.Name == name))
            {
                throw new ArgumentException($"Entity of name '{name}' already exists!", nameof(name));
            }
        }

        protected async Task<TEntity> FindByNameAsyncDetailed(string name)
        {
            var entity = await Repository.GetWithIncludes().FirstOrDefaultAsync(a => a.Name == name);
            if (entity == null)
            {
                throw new ArgumentException($"Entity with name '{name}' not found.", nameof(name));
            }

            return entity;
        }
        
        protected async Task<TEntity> FindByNameAsync(string name)
        {
            var entity = await Repository.Get().FirstOrDefaultAsync(a => a.Name == name);
            if (entity == null)
            {
                throw new ArgumentException($"Entity with name '{name}' not found.", nameof(name));
            }

            return entity;
        }

        #endregion
    }
}