using System.Linq;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Get();

        void Add(TEntity entity);
        
        Task SaveAsync();

        void Remove(TEntity entity);
    }
}