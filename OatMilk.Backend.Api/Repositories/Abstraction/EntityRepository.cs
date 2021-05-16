using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public abstract class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly OatMilkContext _oatMilkContext;
        private readonly DbSet<TEntity> _entityDbSet;

        protected EntityRepository(OatMilkContext oatMilkContext)
        {
            _oatMilkContext = oatMilkContext;
            _entityDbSet = oatMilkContext.GetDbSet<TEntity>();
        }
        
        public virtual IQueryable<TEntity> Get()
        {
            return _entityDbSet.AsQueryable();
        }
        
        public abstract IQueryable<TEntity> GetWithIncludes();
        
        public virtual void Add(TEntity entity)
        {
            _entityDbSet.Add(entity);
        }
        
        public async Task SaveAsync()
        {
            await _oatMilkContext.SaveChangesAsync();
        }
        
        public void Remove(TEntity entity)
        {
            _oatMilkContext.Remove(entity);
        }
    }
}