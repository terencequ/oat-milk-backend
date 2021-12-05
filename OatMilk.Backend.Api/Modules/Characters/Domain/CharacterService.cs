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
using OatMilk.Backend.Api.Modules.Shared.Domain;
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
        
        public Task<PageResponse<CharacterSummaryResponse>> GetMultipleAsSummaryAsync(SearchableSortedPageFilter filter)
        {
            var characterPage = GetEntitiesByPage(filter);
            var result = Mapper.Map<PageResponse<CharacterSummaryResponse>>(characterPage);
            return Task.FromResult(result);
        }
        
        public override async Task<CharacterResponse> CreateAsync(CharacterRequest request)
        {
            var character = DndCharacterCreator.CreateDndCharacter(request);
            await Repository.AddAsync(character);
            return Mapper.Map<CharacterResponse>(character);
        }
    }
}