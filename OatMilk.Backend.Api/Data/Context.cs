using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;

namespace OatMilk.Backend.Api.Data
{
    public class Context : DbContext
    {
        public Context() : base(new DbContextOptions<DbContext>()) { }
        
        public Context(DbContextOptions options): base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<T> GetDbSet<T>() where T: class
        {
            if (typeof(T) == typeof(User))
            {
                return User as DbSet<T>;
            }

            throw new TypeLoadException($"No DbSet of type {typeof(T).Name} exists!");
        }
    }
}
