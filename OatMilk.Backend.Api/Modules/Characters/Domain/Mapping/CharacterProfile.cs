using AutoMapper;
using OatMilk.Backend.Api.Modules.Characters.Data;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Requests.Spells;
using OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses;
using OatMilk.Backend.Api.Modules.Shared.Pagination;
using OatMilk.Backend.Api.Modules.Spells.Data;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Mapping
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterAbilityScoreRequest, CharacterAbilityScore>();
            CreateMap<CharacterAbilityScoreProficiencyRequest, CharacterAbilityScoreProficiency>();
            CreateMap<CharacterAttributeRequest, CharacterAttribute>();
            CreateMap<CharacterDescriptionRequest, CharacterDescription>();
            CreateMap<CharacterSpellRequest, CharacterSpell>();
            CreateMap<CharacterSpellComponentsRequest, SpellComponents>();
            CreateMap<CharacterSpellDurationRequest, SpellDuration>();
            
            CreateMap<Character, CharacterSummaryResponse>()
                .ConvertUsing(c => c.AsSummaryResponse());
            CreateMap<Character, CharacterResponse>()
                .ConvertUsing(c => c.AsResponse());
        }
    }
}
