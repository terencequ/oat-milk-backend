using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly OatMilkContext OatMilkContext;
        private readonly DbSet<TEntity> _entityDbSet;

        protected GenericRepository(OatMilkContext oatMilkContext)
        {
            OatMilkContext = oatMilkContext;
            _entityDbSet = oatMilkContext.GetDbSet<TEntity>();
        }
        
        public virtual IQueryable<TEntity> GetQueryable()
        {
            return _entityDbSet.AsQueryable();
        }

        public IQueryable<TEntity> GetByIdQueryable(Guid id)
        {
            return _entityDbSet.AsQueryable().Where(e => e.Id == id);
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