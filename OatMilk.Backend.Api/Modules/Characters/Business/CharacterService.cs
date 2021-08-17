using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Characters.Business.Helpers;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Shared.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Pagination;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Business
{
    public class CharacterService : UserEntityService<CharacterRequest, Character, CharacterResponse>, ICharacterService
    {
        public CharacterService(IUserEntityRepository<Character> repository, IMapper mapper) : base(repository, mapper)
        {
        }
        
        public Task<PageResponse<CharacterSummaryResponse>> GetMultipleAsSummary(SearchableSortedPageFilter filter)
        {
            var characterPage = GetEntitiesByPage(filter);
            return Task.FromResult(Mapper.Map<PageResponse<CharacterSummaryResponse>>(characterPage));
        }
        
        public override async Task<CharacterResponse> Create(CharacterRequest request)
        {
            var factory = AddOrUpdateCharacter(request);
            var character = factory.Build();
            await Repository.AddAsync(character);
            return Mapper.Map<CharacterResponse>(character);
        }

        public override async Task<CharacterResponse> Update(ObjectId id, CharacterRequest request)
        {
            var factory = AddOrUpdateCharacter(request, Repository.Get().FirstOrDefault(c => c.Id == id));
            var character = factory.Build();
            await Repository.UpdateAsync(character);
            return Mapper.Map<CharacterResponse>(character);
        }

        private DndCharacterFactory AddOrUpdateCharacter(CharacterRequest request, Character existingCharacter = null)
        {
            var factory = new DndCharacterFactory(existingCharacter);
            factory.WithId(existingCharacter?.Id ?? ObjectId.GenerateNewId());
            factory.WithName(request.Name);
            if (request.AbilityScores != null || existingCharacter == null)
            {
                factory.WithAbilityScores(request.AbilityScores);
            }
            if (request.AbilityScoreProficiencies != null || existingCharacter == null)
            {
                factory.WithAbilityScoreProficiencies(request.AbilityScoreProficiencies);
            }
            if (request.Attributes != null || existingCharacter == null)
            {
                factory.WithAttributes(request.Attributes);
            }
            if (request.Descriptions != null || existingCharacter == null)
            {
                factory.WithDescriptions(request.Descriptions);
            }

            return factory;
        }
    }
}