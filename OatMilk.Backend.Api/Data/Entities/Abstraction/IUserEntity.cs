using System;
using MongoDB.Bson;

namespace OatMilk.Backend.Api.Data.Entities.Abstraction
{
    public interface IUserEntity : IAuditableEntity
    {
        /// <summary>
        /// This will be used as an ID that will be enforced on a user level.
        /// </summary>
        string Name { get; set; }
        ObjectId UserId { get; set; }
    }
}