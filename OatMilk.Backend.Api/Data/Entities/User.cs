using System;
using OatMilk.Backend.Api.Data.Entities.Abstraction;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class User : Entity
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }
}
