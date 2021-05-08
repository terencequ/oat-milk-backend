using Microsoft.EntityFrameworkCore;
using System;
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
        
        public DbSet<T> GetDbSet<T>() where T: class
        {
            if (typeof(T) == typeof(User)) { return User as DbSet<T>; }
            if (typeof(T) == typeof(Ability)) { return Ability as DbSet<T>; }
            if (typeof(T) == typeof(Effect)) { return Effect as DbSet<T>; }
            if (typeof(T) == typeof(AbilityEffect)) { return AbilityEffect as DbSet<T>; }
            if (typeof(T) == typeof(Modifier)) { return Modifier as DbSet<T>; }
            
            throw new TypeLoadException($"No DbSet of type {typeof(T).Name} exists!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbilityEffect>()
                .HasKey(abilityEffect => new {abilityEffect.AbilityId, abilityEffect.EffectId});
        }
    }
}
