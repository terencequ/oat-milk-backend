using System.Linq;
using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Repositories
{
    public class UserRepository : EntityRepository<User>
    {
        public UserRepository(OatMilkContext oatMilkContext) : base(oatMilkContext)
        {
        }

        public override IQueryable<User> GetWithIncludes()
        {
            return Get();
        }
    }
}