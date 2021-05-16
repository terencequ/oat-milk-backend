using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using OatMilk.Backend.Api.Data.Entities;

namespace OatMilk.Backend.Api.Data
{
    public class OatMilkContext : DbContext
    {
        public OatMilkContext() : base(new DbContextOptions<DbContext>()) { }
        
        public OatMilkContext(DbContextOptions options): base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Ability> Ability { get; set; }
        public DbSet<Effect> Effect { get; set; }
        public DbSet<AbilityEffect> AbilityEffect { get; set; }
        public DbSet<Modifier> Modifier { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Modifier> Attribute { get; set; }
        
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
            modelBuilder.Entity<AbilityEffect>()
                .HasKey(abilityEffect => new {abilityEffect.AbilityId, abilityEffect.EffectId});
        }
    }
}
