using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OatMilk.Backend.Api.AspNet;

namespace OatMilk.Backend.Api.Modules.Ping
{
    public class PingModule : Module
    {
        public PingModule(IServiceCollection serviceCollection, IMongoDatabase database) : base(serviceCollection, database)
        {
        }

        public override void Register()
        {
            
        }
    }
}