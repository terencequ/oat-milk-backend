using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Services.Abstraction.Interface
{
    public interface IUserEntityService<TRequest, TResponse> : IEntityService<TRequest, TResponse>
    {
        Task<TResponse> GetByName(string id);
    }
}