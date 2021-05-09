using Microsoft.AspNetCore.Http;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;
using OatMilk.Backend.Api.Repositories.Abstraction.Abstract;

namespace OatMilk.Backend.Api.Repositories
{
    public class EffectRepository: UserEntityRepository<Effect>
    {
        public EffectRepository(OatMilkContext oatMilkContext, IHttpContextAccessor httpContextAccessor) : base(oatMilkContext, httpContextAccessor)
        {
        }
    }
}