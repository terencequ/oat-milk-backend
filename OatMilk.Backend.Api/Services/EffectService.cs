using System;
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
        public EffectService(IRepository<Effect> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ModifierResponse> CreateAndAssignModifier(Guid id, ModifierRequest request)
        {
            var effect = await FindByIdAsync(id);

            var modifier = Mapper.Map<Modifier>(request);
            effect.Modifiers.Add(modifier);

            await Repository.SaveAsync();
            return Mapper.Map<ModifierResponse>(modifier);
        }

        public async Task DeleteModifer(Guid id)
        {
            var modifier = await FindByIdAsync();
        }

        #region Helpers

        protected async Task<Modifier> FindModifierById(Guid parentId, Guid modifierId)
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
            return result;
        }

        #endregion
    }
}