using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity :class
    {
        Task<TEntity> FindAsync(params object[] keyValues);
        
        IQueryable<TEntity> Get();

        void Add(TEntity entity);
        
        Task SaveAsync();
    }
}