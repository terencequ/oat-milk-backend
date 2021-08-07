using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OatMilk.Backend.Api.AspNet;
using OatMilk.Backend.Api.Modules.Characters.Business;
using OatMilk.Backend.Api.Modules.Characters.Business.Abstractions;
using OatMilk.Backend.Api.Modules.Characters.Business.Mapping;
using OatMilk.Backend.Api.Modules.Characters.Data;

namespace OatMilk.Backend.Api.Modules.Characters
{
    public class CharactersModule : Module
    {
        public CharactersModule(IServiceCollection serviceCollection, IMongoDatabase database) : base(serviceCollection, database)
        {
        }

        public override void Register()
        {
            RegisterAutoMapperProfiles(typeof(CharacterProfile));
            RegisterService<ICharacterService, CharacterService>();
            CreateIndex<Character>(def => def.Descending(u => u.Name));
            CreateIndex<Character>(def => def.Descending(u => u.CreatedDateTimeUtc));
            CreateIndex<Character>(def => def.Descending(u => u.UpdatedDateTimeUtc));
        }
    }
}