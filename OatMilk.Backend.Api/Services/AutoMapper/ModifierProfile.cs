﻿using AutoMapper;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;

namespace OatMilk.Backend.Api.Services.AutoMapper
{
    public class ModifierProfile : Profile
    {
        public ModifierProfile() : base()
        {
            CreateMap<ModifierRequest, Modifier>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Modifier, ModifierResponse>();
        }
    }
}