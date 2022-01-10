using AutoMapper;
using OatMilk.Backend.Api.Modules.Spells.Data;
using OatMilk.Backend.Api.Modules.Spells.Domain.Models.Requests;

namespace OatMilk.Backend.Api.Modules.Spells.Domain.Mapping
{
    public class SpellProfile : Profile
    {
        public SpellProfile()
        {
            CreateMap<SpellCastingTimeRequest, SpellCastingTime>();
            CreateMap<SpellComponentsRequest, SpellComponents>();
            CreateMap<SpellRangeRequest, SpellRange>();
            CreateMap<SpellDurationRequest, SpellDuration>();
        }
    }
}