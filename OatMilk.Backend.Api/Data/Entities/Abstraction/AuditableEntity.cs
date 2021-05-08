using System;

namespace OatMilk.Backend.Api.Data.Entities.Abstraction
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime UpdatedDateTimeUtc { get; set; }
    }
}