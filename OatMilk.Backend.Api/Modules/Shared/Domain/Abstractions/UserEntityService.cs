using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;
using OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction;
using OatMilk.Backend.Api.Modules.Shared.Pagination;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions
{
    /// <summary>
    /// Base service class for entities that are owned by a user.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class UserEntityService<TRequest, TEntity, TResponse> : EntityService<TRequest, TEntity, TResponse>, IUserEntityService<TRequest, TResponse>
        where TRequest : INamedRequest
        where TEntity : IUserEntity
    {
        public UserEntityService(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        
        public override async Task<TResponse> CreateAsync(TRequest request)
        {
            ThrowIfNameExists(request.Name);
            return await base.CreateAsync(request);
        }

        public virtual Task<PageResponse<TResponse>> GetMultipleAsync(SearchableSortedPageFilter filter)
        {
            var page = GetEntitiesByPage(filter);
            var result = Mapper.Map<PageResponse<TResponse>>(page);
            return Task.FromResult(result);
        }

        public virtual Task<TResponse> GetByIdentifierAsync(string identifier)
        {
            var effect = FindByIdentifier(identifier);
            var result = Mapper.Map<TResponse>(effect);
            return Task.FromResult(result);
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

        protected TEntity FindByIdentifier(string identifier)
        {
            var entity = Repository.Get().FirstOrDefault(a => a.Identifier == identifier);
            if (entity == null)
            {
                throw new ArgumentException($"Entity with identifier '{identifier}' not found.", nameof(identifier));
            }

            return entity;
        }

        protected PageResponse<TEntity> GetEntitiesByPage(SearchableSortedPageFilter filter)
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

            var page = query.GetPageResponse(filter);
            return page;
        }

        #endregion
    }
}