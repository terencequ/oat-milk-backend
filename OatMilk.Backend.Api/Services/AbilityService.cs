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
        private readonly IRepository<Ability> _repository;
        private readonly IMapper _mapper;

        public AbilityService(IConfiguration configuration, IRepository<Ability> repository, IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
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
            if(_repository.Get().Any(a => a.Name == request.Name))
            {
                throw new ArgumentException($"Ability of name '{request.Name}' already exists!", nameof(request.Name));
            }
            
            // Create ability and add it to database
            var entity = _mapper.Map<Ability>(request);
            _repository.Add(entity);
            await _repository.SaveAsync();
            
            return entity.Id;
        }

        /// <summary>
        /// Get single ability for current user.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<AbilityResponse> GetAbility([FromRoute] string name)
        {
            var ability = await _repository.Get().FirstOrDefaultAsync(a => a.Name == name);
            if (ability == null)
            {
                throw new ArgumentException("Ability with name '{name}' not found.", nameof(name));
            }

            return _mapper.Map<AbilityResponse>(ability);
        }
    }
}