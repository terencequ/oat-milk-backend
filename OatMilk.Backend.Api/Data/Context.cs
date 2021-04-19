using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace OatMilk.Backend.Api.Data
{
    public class Context : DbContext
    {
        public Context() : base(new DbContextOptions<DbContext>()) { }
        
        public Context(DbContextOptions options): base(options) { }

        public virtual DbSet<User> User { get; set; }
    }
}
