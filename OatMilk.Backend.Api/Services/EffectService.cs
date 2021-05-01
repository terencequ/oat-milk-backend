using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public Task<EffectResponse> GetEffectFromName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<EffectResponse> UpdateEffect(Guid id, EffectRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEffect(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}