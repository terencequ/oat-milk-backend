using System.Linq;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Retrieve values as a queryable.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> Get();

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
        
        Task RemoveAsync(TEntity entity);
    }
}