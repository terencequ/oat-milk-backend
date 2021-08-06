using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OatMilk.Backend.Api.Configuration;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IMongoDatabase MongoDatabase;
        protected readonly IMongoCollection<TEntity> EntityCollection;
        public Repository(IOptions<DatabaseOptions> databaseOptions)
        {
            var databaseOptionsValue = databaseOptions.Value;
            var client = new MongoClient(databaseOptionsValue.ConnectionString);
            MongoDatabase = client.GetDatabase(databaseOptionsValue.Name);

            EntityCollection = MongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        
        public virtual IQueryable<TEntity> Get()
        {
            return EntityCollection.AsQueryable();
        }

        public virtual Task AddAsync(TEntity entity)
        {
            return EntityCollection.InsertOneAsync(entity);
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            return EntityCollection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }
        
        public virtual async Task RemoveAsync(TEntity entity)
        {
            var result = await EntityCollection.DeleteOneAsync(e => e.Id == entity.Id);
            if (!result.IsAcknowledged)
            {
                throw new Exception("Entity was not removed.");
            }
            if (result.DeletedCount < 1)
            {
                throw new Exception($"Nothing was deleted. Expected to delete 1, deleted {result.DeletedCount}");
            }
        }
    }
}