using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services
{
    public class AbilityService : UserEntityService<AbilityRequest, Ability, AbilityResponse>, IAbilityService
    {
        private readonly IRepository<Effect> _effectRepository;

        public AbilityService(IRepository<Ability> repository, IRepository<Effect> effectRepository, IMapper mapper) : base(repository, mapper)
        {
            _effectRepository = effectRepository;
        }

        public async Task<AbilityResponse> AssignEffect(Guid abilityId, Guid effectId)
        {
            var ability = await FindByIdAsyncDetailed(abilityId);
            var effect = await FindEffectByIdAsync(effectId);

            ability.AbilityEffects.Add(new AbilityEffect() {Ability = ability, Effect = effect});
            await Repository.SaveAsync();
            return Mapper.Map<AbilityResponse>(ability);
        }

        public async Task<AbilityResponse> UnassignEffect(Guid abilityId, Guid effectId)
        {
            var ability = await FindByIdAsyncDetailed(abilityId);
            var abilityEffect = ability.AbilityEffects.FirstOrDefault(ae => ae.EffectId == effectId);
            if (abilityEffect == null)
                throw new ArgumentException($"Effect of ID {effectId} is not assigned to ability of ID {abilityId}.");
            
            ability.AbilityEffects.Remove(abilityEffect);
            await Repository.SaveAsync();
            return Mapper.Map<AbilityResponse>(ability);
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