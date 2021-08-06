using MongoDB.Bson;

namespace OatMilk.Backend.Api.Modules.Shared.Data.Abstraction
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}