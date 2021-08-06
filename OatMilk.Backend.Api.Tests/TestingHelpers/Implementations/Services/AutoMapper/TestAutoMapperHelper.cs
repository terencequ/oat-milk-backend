using System;
using System.Linq;
using AutoMapper;

namespace OatMilk.Backend.Api.Tests.TestingHelpers.Implementations.Services.AutoMapper
{
    public class TestAutoMapperHelper
    {
        /// <summary>
        /// Return a list of defined AutoMapper profile types.
        /// </summary>
        /// <returns></returns>
        public static Type[] GetAutoMapperTypes()
        {
            var autoMapperTypes = AutoMapperHelper.GetAutoMapperTypes();
            var testAutoMapperTypes = autoMapperTypes.ToList();
            testAutoMapperTypes.AddRange(new Type[]
            {
                typeof(TestEntityProfile),
                typeof(TestUserEntityProfile)
            });
            return testAutoMapperTypes.ToArray();
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