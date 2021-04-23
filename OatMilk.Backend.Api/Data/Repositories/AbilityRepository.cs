using System.Linq;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Data.Models.Entities;
using OatMilk.Backend.Api.Data.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Data.Repositories
{
    public class AbilityRepository: BasicRepository<Ability>
    {
        protected AbilityRepository(Context context) : base(context)
        {
        }
    }
}