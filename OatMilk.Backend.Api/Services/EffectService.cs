﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services
{
    public class EffectService : UserEntityService<EffectRequest, Effect, EffectResponse>, IEffectService
    {
        private readonly IRepository<Modifier> _modifierRepository;
        
        public EffectService(IRepository<Effect> repository, IRepository<Modifier> modifierRepository, IMapper mapper) : base(repository, mapper)
        {
            _modifierRepository = modifierRepository;
        }

        public async Task<ModifierResponse> CreateModifier(Guid id, ModifierRequest request)
        {
            var effect = await FindByIdAsync(id);

            var modifier = Mapper.Map<Modifier>(request);
            effect.Modifiers.Add(modifier);

            await Repository.SaveAsync();
            return Mapper.Map<ModifierResponse>(modifier);
        }

        public async Task<ModifierResponse> DeleteModifer(Guid id, Guid modifierId)
        {
            var modifier = await FindModifierById(id, modifierId);
            _modifierRepository.Remove(modifier);
            await Repository.SaveAsync();
            return Mapper.Map<ModifierResponse>(modifier);
        }

        #region Helpers

        private async Task<Modifier> FindModifierById(Guid parentId, Guid modifierId)
        {
            var effect = await Repository.Get()
                .Where(a => a.Id == parentId)
                .Include(a => a.Modifiers)
                .FirstOrDefaultAsync();
            if (effect == null)
            {
                throw new ArgumentException($"Ability with id '{parentId}' not found.", nameof(parentId));
            }
            
            var result = effect.Modifiers.FirstOrDefault(modifier => modifier.Id == modifierId);
            if (result == null)
            {
                throw new ArgumentException($"Effect with id '{modifierId}' not found.", nameof(modifierId));
            }
            
            return result;
        }

        #endregion
    }
}