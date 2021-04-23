using Microsoft.EntityFrameworkCore;
using OatMilk.Backend.Api.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
        public DbSet<Ability> Ability { get; set; }
        public DbSet<Effect> Effect { get; set; }
        public DbSet<Modifier> Modifier { get; set; }
        
        public DbSet<T> GetDbSet<T>() where T: class
        {
            if (typeof(T) == typeof(User)) { return User as DbSet<T>; }
            if (typeof(T) == typeof(Ability)) { return Ability as DbSet<T>; }
            if (typeof(T) == typeof(Effect)) { return Effect as DbSet<T>; }
            if (typeof(T) == typeof(Modifier)) { return Modifier as DbSet<T>; }
            
            throw new TypeLoadException($"No DbSet of type {typeof(T).Name} exists!");
        }
    }
}
