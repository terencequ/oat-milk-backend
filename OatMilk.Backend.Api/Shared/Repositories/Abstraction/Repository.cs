using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Shared.Repositories.Abstraction
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly OatMilkContext OatMilkContext;
        private readonly DbSet<TEntity> _entityDbSet;

        public Repository(OatMilkContext oatMilkContext)
        {
            OatMilkContext = oatMilkContext;
            _entityDbSet = oatMilkContext.GetDbSet<TEntity>();
        }
        
        public virtual IQueryable<TEntity> Get()
        {
            return _entityDbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetWithIncludes()
        {
            return _entityDbSet.AsQueryable();
        }
        
        public virtual void Add(TEntity entity)
        {
            _entityDbSet.Add(entity);
        }

        public async Task SaveAsync()
        {
            await OatMilkContext.SaveChangesAsync();
        }
        
        public virtual void Remove(TEntity entity)
        {
            OatMilkContext.Remove(entity);
        }
    }
}