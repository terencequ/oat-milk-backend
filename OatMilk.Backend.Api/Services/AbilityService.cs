using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

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

        /// <summary>
        /// Create ability for current user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Guid of newly created ability.</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Guid> CreateAbility(AbilityRequest request)
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

            return entity.Id;
        }

        /// <summary>
        /// Get single ability for current user.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<AbilityResponse> GetAbilityByName([FromRoute] string name)
        {
            var ability = await FindAbilityByNameAsync(name);
            return _mapper.Map<AbilityResponse>(ability);
        }

        /// <summary>
        /// Update an existing ability.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<AbilityResponse> UpdateAbility(Guid id, AbilityRequest request)
        {
            var ability = await FindAbilityByIdAsync(id);
            _mapper.Map(request, ability);

            return _mapper.Map<Ability, AbilityResponse>(ability);
        }

        /// <summary>
        /// Delete an existing ability.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentException"></exception>
        public async Task DeleteAbility(Guid id)
        {
            var ability = await FindAbilityByIdAsync(id);

            _abilityRepository.Remove(ability);
            await _abilityRepository.SaveAsync();
        }

        /// <summary>
        /// Create effect for existing ability.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
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