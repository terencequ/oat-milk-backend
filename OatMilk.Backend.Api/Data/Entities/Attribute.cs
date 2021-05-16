using System.Collections.Generic;
using System.Linq;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class Attribute : AuditableEntity
    {
        public string Type { get; set; }
        public double BaseValue { get; set; }
        public double CurrentValue { get; set; }
    }
}