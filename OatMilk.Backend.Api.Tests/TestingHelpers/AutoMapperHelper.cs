using System;
using AutoMapper;
using OatMilk.Backend.Api.Modules.Characters.Business.Automapper;
using OatMilk.Backend.Api.Modules.Users.Business.Automapper;

namespace OatMilk.Backend.Api.Modules.Core.AspNet
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
                typeof(UserProfile),
                typeof(CharacterProfile),
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