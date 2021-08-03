using System;
using MongoDB.Bson;

namespace OatMilk.Backend.Api.Data.Entities.Abstraction
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}