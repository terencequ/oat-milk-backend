using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Repositories
{
    public class EffectRepository: UserEntityRepository<Effect>
    {
        public EffectRepository(OatMilkContext oatMilkContext, IHttpContextAccessor httpContextAccessor) : base(oatMilkContext, httpContextAccessor)
        {
        }

        public override IQueryable<Effect> GetWithIncludes()
        {
            return Get()
                .Include(effect => effect.Modifiers);
        }
    }
}