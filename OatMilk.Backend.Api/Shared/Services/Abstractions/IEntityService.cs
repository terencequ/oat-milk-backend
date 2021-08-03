using System;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Shared.Services.Abstractions
{
    public interface IEntityService<in TRequest, TResponse>
    {
        Task<TResponse> Create(TRequest request);
        Task<TResponse> GetById(Guid id);
        Task<TResponse> Update(Guid id, TRequest request);
        Task Delete(Guid id);
    }
}