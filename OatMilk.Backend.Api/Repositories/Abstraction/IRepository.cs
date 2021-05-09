using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity :class
    {
        IQueryable<TEntity> Get();

        void Add(TEntity entity);
        
        Task SaveAsync();

        void Remove(TEntity entity);
    }
}