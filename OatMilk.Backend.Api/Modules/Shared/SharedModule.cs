using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OatMilk.Backend.Api.AspNet;

namespace OatMilk.Backend.Api.Modules.Shared
{
    public class SharedModule : Module
    {
        public SharedModule(IServiceCollection serviceCollection, IMongoDatabase database) : base(serviceCollection, database)
        {
        }

        public override void Register()
        {
            
        }
    }
}