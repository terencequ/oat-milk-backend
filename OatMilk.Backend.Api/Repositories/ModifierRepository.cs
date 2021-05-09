using Microsoft.AspNetCore.Http;
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
    }
}