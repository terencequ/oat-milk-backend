using AutoMapper;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.AutoMapper
{
    public class EffectProfile : Profile
    {
        public EffectProfile()
        {
            CreateMap<EffectRequest, Effect>();
            CreateMap<Effect, EffectResponse>();
        }
    }
}
