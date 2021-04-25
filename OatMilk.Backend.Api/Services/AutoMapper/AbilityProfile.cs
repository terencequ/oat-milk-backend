﻿using AutoMapper;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.AutoMapper
{
    public class AbilityProfile : Profile
    {
        public AbilityProfile() : base()
        {
            CreateMap<AbilityRequest, Ability>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Ability, AbilityResponse>();
        }
    }
}