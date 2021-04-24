using OatMilk.Backend.Api.Data;
using OatMilk.Backend.Api.Data.Entities;
using OatMilk.Backend.Api.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Repositories
{
    public class UserRepository : BasicRepository<User>
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}