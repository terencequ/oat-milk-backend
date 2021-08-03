using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Data.Entities;

namespace OatMilk.Backend.Api.Data
{
    public static class DatabaseSetup
    {
        public static IServiceCollection SetupDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseOptions = configuration.GetSection(DatabaseOptions.Database).Get<DatabaseOptions>();
            var client = new MongoClient(databaseOptions.ConnectionString);
            var database = client.GetDatabase(databaseOptions.Name);
            
            // Setup users
            database.CreateIndex<User>(def => def.Descending(u => u.CreatedDateTimeUtc));
            database.CreateIndex<User>(def => def.Descending(u => u.UpdatedDateTimeUtc));

            // Setup characters
            database.CreateIndex<Character>(def => def.Descending(u => u.Name));
            database.CreateIndex<Character>(def => def.Descending(u => u.CreatedDateTimeUtc));
            database.CreateIndex<Character>(def => def.Descending(u => u.UpdatedDateTimeUtc));
            
            return services;
        }
        
        private static void CreateIndex<T>(this IMongoDatabase database, Func<IndexKeysDefinitionBuilder<T>, IndexKeysDefinition<T>> buildIndex)
        {
            var collection = database.GetCollection<T>(typeof(T).Name);
            var indexKeysDefinition = buildIndex(Builders<T>.IndexKeys);
            var indexModel = new CreateIndexModel<T>(indexKeysDefinition);
            collection.Indexes.CreateOne(indexModel);
        }
    }
}