using System;
using System.Linq;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Repositories.Abstraction
{
    public interface IUserRepository<TEntity> : IRepository<TEntity> where TEntity : UserEntity
    {
    }
}