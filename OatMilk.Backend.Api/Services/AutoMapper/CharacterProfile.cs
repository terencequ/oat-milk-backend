﻿using AutoMapper;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.AutoMapper
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterRequest, Character>();
            CreateMap<Character, CharacterResponse>();
        }
    }
}