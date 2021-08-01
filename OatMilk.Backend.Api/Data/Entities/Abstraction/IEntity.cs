using System;

namespace OatMilk.Backend.Api.Data.Entities.Abstraction
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}