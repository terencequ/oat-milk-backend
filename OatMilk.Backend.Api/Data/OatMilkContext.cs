using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using OatMilk.Backend.Api.Data.Entities;

namespace OatMilk.Backend.Api.Data
{
    public class OatMilkContext : DbContext
    {
        public OatMilkContext() : base(new DbContextOptions<DbContext>()) { }
        
        public OatMilkContext(DbContextOptions options): base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Character> Character { get; set; }

        public DbSet<T> GetDbSet<T>() where T: class
        {
            var type = typeof(OatMilkContext)
                .GetProperties()
                .FirstOrDefault(property => property.PropertyType == typeof(DbSet<T>));
            if (type != null)
            {
                return type.GetMethod?.Invoke(this, Array.Empty<object>()) as DbSet<T>;
            }

            throw new TypeLoadException($"No DbSet of type {typeof(T).Name} exists!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
