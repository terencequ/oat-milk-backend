using AutoMapper;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Mapping
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterSummaryResponse>()
                .ConvertUsing(c => c.AsSummaryResponse());
            CreateMap<Character, CharacterResponse>()
                .ConvertUsing(c => c.AsResponse());
            CreateMap<PageResponse<Character>, PageResponse<CharacterResponse>>();
            CreateMap<PageResponse<Character>, PageResponse<CharacterSummaryResponse>>();
        }
    }
}
