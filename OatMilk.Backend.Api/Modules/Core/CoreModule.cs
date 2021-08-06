using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OatMilk.Backend.Api.AspNet;

namespace OatMilk.Backend.Api.Modules.Core
{
    public class CoreModule : Module
    {
        public CoreModule(IServiceCollection serviceCollection, IMongoDatabase database) : base(serviceCollection, database)
        {
        }

        public override void Register()
        {
            
        }
    }
}