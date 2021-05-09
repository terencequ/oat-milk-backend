using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Repositories.Abstraction.Interface
{
    public interface IRepository<TEntity> where TEntity :class
    {
        IQueryable<TEntity> Get();

        void Add(TEntity entity);
        
        Task SaveAsync();

        void Remove(TEntity entity);
    }
}