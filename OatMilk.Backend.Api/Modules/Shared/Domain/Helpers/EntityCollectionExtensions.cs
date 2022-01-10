using System;
using System.Collections.Generic;
using System.Linq;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Helpers
{
    /// <summary>
    /// Helper functions for working with <see cref="ICollection{T}"/>.
    /// </summary>
    public static class EntityCollectionExtensions
    {
        public static TEntity GetById<TEntity>(this ICollection<TEntity> entities, string id)
            where TEntity : IChildEntity
        {
            return entities.FirstOrDefault(r => r.Id == id) 
                   ?? throw new NullReferenceException($"{typeof(TEntity).Name} of id ({id}) does not exist.");
        } 
        
        public static TEntity GetByIdOrDefault<TEntity>(this ICollection<TEntity> entities, string id)
        where TEntity : IChildEntity
        {
            return entities.FirstOrDefault(r => r.Id == id);
        } 
        
        public static bool ExistsById<TEntity>(this ICollection<TEntity> entities, string id)
            where TEntity : IChildEntity
        {
            return entities.Any(r => r.Id == id);
        } 
        
        public static void RemoveById<TEntity>(this ICollection<TEntity> entities, string id)
            where TEntity : class, IChildEntity
        {
            var entity = entities?.FirstOrDefault(s => s.Id == id);
            if(entity != null)
            {
                entities.Remove(entity);
            }
        }
    }
}