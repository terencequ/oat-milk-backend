using System;
using System.Collections.Generic;
using System.Linq;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;
using OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Domain.Helpers
{
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

        /// <summary>
        /// Update a collection of entities with a collection of requests.
        /// </summary>
        /// <param name="entities">Collection to update</param>
        /// <param name="requests">Collection of requests</param>
        /// <param name="addOrUpdateAction">Action to map a request to an existing or new entity.</param>
        /// <param name="matchPredicate">Optional custom function to match a TEntity with TRequest. Default is to check by ID.</param>
        /// <typeparam name="TEntity">Type of entity to update</typeparam>
        /// <typeparam name="TRequest">Type of request to update entity</typeparam>
        public static void UpdateWithRequests<TEntity, TRequest>(
            this ICollection<TEntity> entities,
            ICollection<TRequest> requests, 
            Func<TEntity, TRequest, TEntity> addOrUpdateAction,
            Func<TEntity, TRequest, bool> matchPredicate = null) 
            where TEntity : class, IChildEntity 
            where TRequest : class, IUniqueRequest
        {
            matchPredicate ??= (entity, request) => entity.Id == request.Id;

            // delete
            var entitiesToDelete = entities.Where(entity => 
                requests.All(request => !matchPredicate(entity, request))).ToList(); // entities which don't exist in requests
            foreach (var entity in entitiesToDelete) {
                entities.Remove(entity);
            }
                
            // update
            var entitiesToUpdate = entities.Where(entity => 
                requests.Any(request => matchPredicate(entity, request))).ToList(); // entities which exists in requests
            foreach (var entity in entitiesToUpdate) {
                addOrUpdateAction(entity, requests.FirstOrDefault(r => matchPredicate(entity, r)));
            }
                
            // create
            var requestsForCreation = requests.Where(request => 
                entities.All(entity => !matchPredicate(entity, request))).ToList(); // requests which don't exist in entities
            foreach (var request in requestsForCreation) {
                entities.Add(addOrUpdateAction(null, request));
            }
        }
    }
}