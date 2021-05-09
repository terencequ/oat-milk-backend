﻿using System;
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
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services
{
    public class AbilityService : UserEntityService<AbilityRequest, Ability, AbilityResponse>, IAbilityService
    {
        private readonly IRepository<Effect> _effectRepository;

        public AbilityService(IRepository<Ability> repository, IRepository<Effect> effectRepository, IMapper mapper) : base(repository, mapper)
        {
            _effectRepository = effectRepository;
        }

        public async Task<PageResponse<AbilityResponse>> GetMultiple(SearchableSortedPageFilter filter)
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
                .ProjectTo<AbilityResponse>(Mapper.ConfigurationProvider)
                .GetPageResponseAsync(filter);
        }

        public async Task AssignEffect(Guid abilityId, Guid effectId)
        {
            var ability = await FindByIdAsync(abilityId);
            var effect = await FindEffectByIdAsync(effectId);
            
            ability.AbilityEffects.Add(new AbilityEffect(){Ability = ability, Effect = effect});
            await Repository.SaveAsync();
        }
        
        #region Helpers

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