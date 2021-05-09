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