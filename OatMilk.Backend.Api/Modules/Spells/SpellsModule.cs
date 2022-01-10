using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OatMilk.Backend.Api.AspNet;
using OatMilk.Backend.Api.Modules.Spells.Domain.Mapping;

namespace OatMilk.Backend.Api.Modules.Spells
{
    /// <summary>
    /// This Module represents:
    /// - A user managing their own spells.
    /// - Model definitions for spells to be used in other areas.
    /// </summary>
    public class SpellsModule : Module
    {
        public SpellsModule(IServiceCollection serviceCollection, IMongoDatabase database) : base(serviceCollection, database)
        {
        }

        public override void Register()
        {
            RegisterAutoMapperProfiles(typeof(SpellProfile));
        }
    }
}