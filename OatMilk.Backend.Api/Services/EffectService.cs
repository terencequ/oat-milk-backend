using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Services.Abstraction;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services
{
    public class EffectService : IEffectService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Effect> _effectRepository;
        private readonly IMapper _mapper;

        public EffectService(IConfiguration configuration, IRepository<Effect> effectRepository, IMapper mapper)
        {
            _configuration = configuration;
            _effectRepository = effectRepository;
            _mapper = mapper;
        }
        
        public async Task<EffectResponse> CreateEffect(EffectRequest request)
        {
            // Check for duplicate name
            if (_effectRepository.Get().Any(a => a.Name == request.Name))
            {
                throw new ArgumentException($"Ability of name '{request.Name}' already exists!", nameof(request.Name));
            }

            // Create ability and add it to database
            var entity = _mapper.Map<Effect>(request);
            _effectRepository.Add(entity);
            await _effectRepository.SaveAsync();

            return _mapper.Map<EffectResponse>(entity);
        }

        public async Task<EffectResponse> GetEffectById(Guid id)
        {
            var effect = await FindEffectByIdAsync(id);
            return _mapper.Map<EffectResponse>(effect);
        }
        
        public async Task<EffectResponse> GetEffectByName(string name)
        {
            var effect = await FindEffectByNameAsync(name);
            return _mapper.Map<EffectResponse>(effect);
        }

        public async Task<EffectResponse> UpdateEffect(Guid id, EffectRequest request)
        {
            var effect = await FindEffectByIdAsync(id);
            _mapper.Map(request, effect);
            await _effectRepository.SaveAsync();
            
            return _mapper.Map<Effect, EffectResponse>(effect);
        }

        public async Task DeleteEffect(Guid id)
        {
            var effect = await FindEffectByIdAsync(id);

            _effectRepository.Remove(effect);
            await _effectRepository.SaveAsync();
        }
        
        #region Helpers

        private async Task<Effect> FindEffectByNameAsync(string name)
        {
            var effect = await _effectRepository.Get().FirstOrDefaultAsync(a => a.Name == name);
            if (effect == null)
            {
                throw new ArgumentException($"Ability with name '{name}' not found.", nameof(name));
            }

            return effect;
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