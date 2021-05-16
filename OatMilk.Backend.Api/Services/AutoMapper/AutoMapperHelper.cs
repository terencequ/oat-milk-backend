﻿using System;
using System.IO.Pipes;
using AutoMapper;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using Attribute = OatMilk.Backend.Api.Data.Entities.Attribute;

namespace OatMilk.Backend.Api.Services.AutoMapper
{
    public static class AutoMapperHelper
    {
        /// <summary>
        /// Return a list of defined AutoMapper profile types.
        /// </summary>
        /// <returns></returns>
        public static Type[] GetAutoMapperTypes()
        {
            return new []
            {
                typeof(EntityProfile<UserRequest, User, UserResponse>),
                typeof(EntityProfile<AbilityRequest, Ability, AbilityResponse>),
                typeof(EntityProfile<AttributeRequest, Attribute, AttributeResponse>),
                typeof(EntityProfile<CharacterRequest, Character, CharacterResponse>),
                typeof(EntityProfile<EffectRequest, Effect, EffectResponse>),
                typeof(EntityProfile<ModifierRequest, Modifier, ModifierResponse>)
            };
        }

        /// <summary>
        /// Create an AutoMapper using all profiles defined.
        /// </summary>
        /// <returns></returns>
        public static IMapper GetAutoMapper()
        {
            return new MapperConfiguration(config =>
            {
                foreach (var profileType in GetAutoMapperTypes())
                {
                    config.AddProfile(profileType);
                }
            }).CreateMapper();
        }
    }
}