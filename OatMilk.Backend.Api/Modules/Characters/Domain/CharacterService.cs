using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Characters.Domain.Helpers;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses;
using OatMilk.Backend.Api.Modules.Shared.Domain.Abstractions;
using OatMilk.Backend.Api.Modules.Shared.Pagination;
using OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Modules.Characters.Domain
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
        
        public override async Task<CharacterResponse> CreateAsync(CharacterRequest request)
        {
            var character = AddOrUpdateCharacter(request);
            await Repository.AddAsync(character);
            return Mapper.Map<CharacterResponse>(character);
        }

        public override async Task<CharacterResponse> UpdateAsync(ObjectId id, CharacterRequest request)
        {
            var character = AddOrUpdateCharacter(request, Repository.Get().FirstOrDefault(c => c.Id == id));
            await Repository.UpdateAsync(character);
            return Mapper.Map<CharacterResponse>(character);
        }

        private Character AddOrUpdateCharacter(CharacterRequest request, Character existingCharacter = null)
        {
            var factory = new DndCharacterFactory(Mapper, existingCharacter);
            factory.WithId(existingCharacter?.Id ?? ObjectId.GenerateNewId());
            factory.WithName(request.Name);

            void PerformRequestAction<TRequest>(ICollection<TRequest> requests, Action<ICollection<TRequest>> requestAction)
            {
                // Only perform action if:
                // a) Requests are not null (null request collections should be ignored)
                // b) OR Existing character is null (this is a new character, they should start with at least a basic template)
                if (requests != null || existingCharacter == null)
                {
                    requestAction(requests);
                }
            }
            
            PerformRequestAction(request.AbilityScores, factory.WithAbilityScores);
            PerformRequestAction(request.AbilityScoreProficiencies, factory.WithAbilityScoreProficiencies);
            PerformRequestAction(request.Attributes, factory.WithAttributes);
            PerformRequestAction(request.Descriptions, factory.WithDescriptions);
            PerformRequestAction(request.Spells, factory.WithSpells);
            
            return factory.Build();
        }
    }
}