using AutoMapper;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Business.Models.Responses;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Shared.Pagination;

namespace OatMilk.Backend.Api.Modules.Characters.Business.Automapper
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterRequest, Character>();
            CreateMap<Character, CharacterResponse>();
            CreateMap<PageResponse<Character>, PageResponse<CharacterResponse>>();
        }
    }
}
