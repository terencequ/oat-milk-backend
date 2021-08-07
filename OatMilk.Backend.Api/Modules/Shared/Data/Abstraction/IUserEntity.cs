using MongoDB.Bson;

namespace OatMilk.Backend.Api.Modules.Shared.Data.Abstraction
{
    public interface IUserEntity : IAuditableEntity
    {
        /// <summary>
        /// This will be used as a user-friendly ID
        /// </summary>
        string Identifier { get; set; }
        string Name { get; set; }
        ObjectId UserId { get; set; }
    }
}