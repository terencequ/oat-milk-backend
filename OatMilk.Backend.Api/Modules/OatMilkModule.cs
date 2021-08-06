using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OatMilk.Backend.Api.AspNet;
using OatMilk.Backend.Api.Modules.Characters;
using OatMilk.Backend.Api.Modules.Core;
using OatMilk.Backend.Api.Modules.Ping;
using OatMilk.Backend.Api.Modules.Shared;
using OatMilk.Backend.Api.Modules.Users;

namespace OatMilk.Backend.Api.Modules
{
    /// <summary>
    /// Main app module.
    /// </summary>
    /// <remarks>
    /// When registering for <see cref="Startup"/>,
    /// create a new <see cref="Module"/> class and add it to the <see cref="Module.Register"/> method.
    /// </remarks>
    public class OatMilkModule : Module
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IMongoDatabase _database;

        public OatMilkModule(IServiceCollection serviceCollection, IMongoDatabase database) : base(serviceCollection, database)
        {
            _serviceCollection = serviceCollection;
            _database = database;
        }

        /// <summary>
        /// Entry point registration method used in <see cref="OatMilkStartupExtensions"/>.
        /// </summary>
        public override void Register()
        {
            var modules = new List<Module>()
            {
                new CoreModule(_serviceCollection, _database),
                new SharedModule(_serviceCollection, _database),
                new CharactersModule(_serviceCollection, _database),
                new PingModule(_serviceCollection, _database),
                new SharedModule(_serviceCollection, _database),
                new UserModule(_serviceCollection, _database)
            };
            
            foreach (var module in modules)
            {
                module.Register();
            }
        }
    }
}