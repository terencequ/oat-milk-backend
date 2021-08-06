using System;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace OatMilk.Backend.Api.AspNet
{
    public abstract class Module
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IMongoDatabase _database;

        protected Module(IServiceCollection serviceCollection, IMongoDatabase database)
        {
            _serviceCollection = serviceCollection;
            _database = database;
        }
        
        public abstract void Register();

        #region Helper methods

        protected void CreateIndex<T>(Func<IndexKeysDefinitionBuilder<T>, IndexKeysDefinition<T>> buildIndex)
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            var indexKeysDefinition = buildIndex(Builders<T>.IndexKeys);
            var indexModel = new CreateIndexModel<T>(indexKeysDefinition);
            collection.Indexes.CreateOne(indexModel);
        }

        protected void RegisterService<TServiceInterface, TService>() 
            where TServiceInterface : class
            where TService : class, TServiceInterface
        {
            _serviceCollection.AddScoped<TServiceInterface, TService>();
        }

        #endregion
    }
}