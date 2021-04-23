﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Models.Entities;
using OatMilk.Backend.Api.Data.Repositories.Abstraction;

namespace OatMilk.Backend.Api.Data.Repositories
{
    public class UserRepository : BasicRepository<User>
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}