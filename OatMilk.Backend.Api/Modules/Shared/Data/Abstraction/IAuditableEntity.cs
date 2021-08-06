using System;

namespace OatMilk.Backend.Api.Modules.Shared.Data.Abstraction
{
    public interface IAuditableEntity : IEntity
    {
        DateTime CreatedDateTimeUtc { get; set; }
        DateTime UpdatedDateTimeUtc { get; set; }
    }
}