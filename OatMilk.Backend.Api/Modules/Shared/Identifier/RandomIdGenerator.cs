using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using OatMilk.Backend.Api.Modules.Shared.Data.Abstraction;

namespace OatMilk.Backend.Api.Modules.Shared.Identifier
{
    public static class RandomIdGenerator
    {
        private static readonly char[] Base36CharsWithoutVowels = 
            "0123456789BCDFGHJKLMNPQRSTVWXYZ"
                .ToCharArray();

        private static readonly Random Random = new Random();
        
        /// <summary>
        /// Generate a Base36 string of specified length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetBase36(int length) 
        {
            var sb = new StringBuilder(length);

            for (int i=0; i<length; i++) 
                sb.Append(Base36CharsWithoutVowels[Random.Next(31)]);

            return sb.ToString();
        }

        private const int DefaultIdLength = 8;
        private const int DefaultMaxGenerationAttempts = 100;
        
        /// <inheritdoc cref="GetBase36{TEntity}(IQueryable{TEntity}, Func{TEntity, string}, int, int)"/>
        public static string GetBase36<TEntity>(
            ICollection<TEntity> existingEntities, 
            Func<TEntity, string> idSelector, 
            int idLength = DefaultIdLength, 
            int maxGenerationAttempts = DefaultMaxGenerationAttempts)
        {
            var id = GetBase36(idLength);
            
            // Generate ID and check dupe
            for (var i = 0; i < maxGenerationAttempts; i++)
            {
                var conflictingEntity = existingEntities.FirstOrDefault(e => idSelector(e) == id);
                if(conflictingEntity == null)
                    return id;
                id = GetBase36(idLength);
            }
            
            throw new Exception("Id could not be successfully inserted! Somehow we are running out of Id's!");
        }

        /// <summary>
        /// Get a Base36 string that is unique in the specified collection.
        /// </summary>
        /// <param name="entityCollection">Collection of existing entities</param>
        /// <param name="idLength">Length of ID to generate</param>
        /// <param name="maxGenerationAttempts">Max attempts to generate ID before exception is thrown</param>
        /// <typeparam name="TUserEntity">Type of entity which needs new ID</typeparam>
        /// <returns></returns>
        /// <exception cref="Exception">Thrown if all attempts have collisions</exception>
        public static string GetBase36<TUserEntity>(
            IMongoCollection<TUserEntity> entityCollection,
            int idLength = DefaultIdLength, 
            int maxGenerationAttempts = DefaultMaxGenerationAttempts)
        where TUserEntity : IUserEntity
        {
            var id = GetBase36(idLength);
            
            // Generate ID and check dupe
            for (var i = 0; i < maxGenerationAttempts; i++)
            {
                var currentId = id;
                var conflictingEntity = entityCollection
                    .Find(e => e.Identifier == currentId)
                    .FirstOrDefault();
                if(conflictingEntity == null)
                    return id;
                id = GetBase36(idLength);
            }
            
            throw new Exception("Id could not be successfully inserted! Somehow we are running out of Id's!");
        }
    }
}