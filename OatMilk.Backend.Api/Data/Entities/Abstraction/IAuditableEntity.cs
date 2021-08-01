using System;

namespace OatMilk.Backend.Api.Data.Entities.Abstraction
{
    public interface IAuditableEntity : IEntity
    {
        DateTime CreatedDateTimeUtc { get; set; }
        DateTime UpdatedDateTimeUtc { get; set; }
    }
}