using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class Attribute : AuditableEntity
    {
        public int BaseValue { get; set; }
        public int CurrentValue { get; set; }
    }
}