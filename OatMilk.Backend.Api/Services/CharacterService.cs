using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Data.Extensions;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services
{
    public class CharacterService: UserEntityService<CharacterRequest, Character, CharacterResponse>, ICharacterService
    {
        protected readonly IRepository<Ability> AbilityRepository;

        public CharacterService(IRepository<Character> repository, IRepository<Ability> abilityRepository, IMapper mapper) : base(repository, mapper)
        {
            AbilityRepository = abilityRepository;
        }

        /// <summary>
        /// Different implementation of Create.
        /// This will set up attributes in addition to persisting a character.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public new async Task<CharacterResponse> Create(CharacterRequest request)
        {
            var response = await base.Create(request);
            return await ResetCharacter(response.Id); 
        }
        
        /// <summary>
        /// Reset the character.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<CharacterResponse> ResetCharacter(Guid id)
        {
            var entity = await FindByIdAsyncDetailed(id);
            entity.ResetAndSetupAttributes();
            await Repository.SaveAsync();

            return Mapper.Map<CharacterResponse>(entity);
        }

        /// <summary>
        /// Apply an ability's effects to a character.
        /// </summary>
        /// <returns></returns>
        public async Task<CharacterResponse> ApplyAbilityAsTarget(Guid id, Guid abilityId)
        {
            var character = await FindByIdAsyncDetailed(id);
            var ability = await FindAbilityByIdAsync(id);
            
            var effects = from ae in ability.AbilityEffects select ae.Effect;
            foreach (var effect in effects)
            {
                character.Attributes.ApplyEffect(effect);
            }

            await Repository.SaveAsync();
            return Mapper.Map<CharacterResponse>(effects);
        }

        #region Helpers

        protected async Task<Ability> FindAbilityByIdAsync(Guid id)
        {
            var entity = await AbilityRepository.Get()
                .Include(ability => ability.AbilityEffects)
                .ThenInclude(abilityEffect => abilityEffect.Effect)
                .ThenInclude(effect => effect.Modifiers)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null)
            {
                throw new ArgumentException($"Ability with id '{id}' not found.", nameof(id));
            }

            return entity;
        }

        #endregion
    }
}