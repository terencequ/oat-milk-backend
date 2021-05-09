using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Filters;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services
{
    public class AbilityService : IAbilityService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Ability> _abilityRepository;
        private readonly IRepository<Effect> _effectRepository;
        private readonly IMapper _mapper;

        public AbilityService(IConfiguration configuration, IRepository<Ability> abilityRepository, IRepository<Effect> effectRepository, IMapper mapper)
        {
            _configuration = configuration;
            _abilityRepository = abilityRepository;
            _effectRepository = effectRepository;
            _mapper = mapper;
        }
        
        public async Task<AbilityResponse> CreateAbility(AbilityRequest request)
        {
            // Check for duplicate name
            if (_abilityRepository.Get().Any(a => a.Name == request.Name))
            {
                throw new ArgumentException($"Ability of name '{request.Name}' already exists!", nameof(request.Name));
            }

            // Create ability and add it to database
            var entity = _mapper.Map<Ability>(request);
            _abilityRepository.Add(entity);
            await _abilityRepository.SaveAsync();

            return _mapper.Map<AbilityResponse>(entity);
        }
        
        public async Task<PageResponse<AbilityResponse>> GetAbilities(AbilityFilter filter)
        {
            var query = _abilityRepository
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
                .ProjectTo<AbilityResponse>(_mapper.ConfigurationProvider)
                .GetPageResponseAsync(filter);
        }
        
        public async Task<AbilityResponse> GetAbilityById(Guid id)
        {
            var ability = await FindAbilityByIdAsync(id);
            return _mapper.Map<AbilityResponse>(ability);
        }
        
        public async Task<AbilityResponse> GetAbilityByName(string name)
        {
            var ability = await FindAbilityByNameAsync(name);
            return _mapper.Map<AbilityResponse>(ability);
        }
        
        public async Task<AbilityResponse> UpdateAbility(Guid id, AbilityRequest request)
        {
            var ability = await FindAbilityByIdAsync(id);
            _mapper.Map(request, ability);
            await _abilityRepository.SaveAsync();
            
            return _mapper.Map<Ability, AbilityResponse>(ability);
        }
        
        public async Task DeleteAbility(Guid id)
        {
            var ability = await FindAbilityByIdAsync(id);

            _abilityRepository.Remove(ability);
            await _abilityRepository.SaveAsync();
        }
        
        public async Task AssignEffectToAbility(Guid abilityId, Guid effectId)
        {
            var ability = await FindAbilityByIdAsync(abilityId);
            var effect = await FindEffectByIdAsync(effectId);
            
            ability.AbilityEffects.Add(new AbilityEffect(){Ability = ability, Effect = effect});
            await _abilityRepository.SaveAsync();
        }
        
        #region Helpers

        private async Task<Ability> FindAbilityByNameAsync(string name)
        {
            var ability = await _abilityRepository.Get().FirstOrDefaultAsync(a => a.Name == name);
            if (ability == null)
            {
                throw new ArgumentException($"Ability with name '{name}' not found.", nameof(name));
            }

            return ability;
        }
        
        private async Task<Ability> FindAbilityByIdAsync(Guid id)
        {
            var ability = await _abilityRepository.Get().FirstOrDefaultAsync(a => a.Id == id);
            if (ability == null)
            {
                throw new ArgumentException($"Ability with id '{id}' not found.", nameof(id));
            }

            return ability;
        }
        
        private async Task<Effect> FindEffectByIdAsync(Guid id)
        {
            var effect = await _effectRepository.Get().FirstOrDefaultAsync(a => a.Id == id);
            if (effect == null)
            {
                throw new ArgumentException($"Ability with id '{id}' not found.", nameof(id));
            }

            return effect;
        }

        #endregion
    }
}