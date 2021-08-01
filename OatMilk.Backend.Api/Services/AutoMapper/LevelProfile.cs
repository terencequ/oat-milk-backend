using AutoMapper;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.AutoMapper
{
    public class LevelProfile : Profile
    {
        public LevelProfile()
        {
            CreateMap<LevelRequest, Level>();
            CreateMap<Level, LevelResponse>();
        }
    }
}