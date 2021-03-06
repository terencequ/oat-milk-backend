using System;
using AutoMapper;
using OatMilk.Backend.Api.Modules.Characters.Domain.Mapping;
using OatMilk.Backend.Api.Modules.Shared.Domain.Automapper;
using OatMilk.Backend.Api.Modules.Spells.Domain.Mapping;
using OatMilk.Backend.Api.Modules.Users.Domain.Automapper;

namespace OatMilk.Backend.Api.Tests.TestingHelpers
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
                typeof(PaginationProfile),
                typeof(UserProfile),
                typeof(CharacterProfile),
                typeof(SpellProfile)
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