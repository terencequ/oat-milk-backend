using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Repositories
{
    public class ModifierRepository: EntityRepository<Modifier>
    {
        public ModifierRepository(OatMilkContext oatMilkContext) : base(oatMilkContext)
        {
        }

        public override IQueryable<Modifier> GetWithIncludes()
        {
            return Get();
        }
    }
}