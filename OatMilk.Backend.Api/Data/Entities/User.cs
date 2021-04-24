using System;

namespace OatMilk.Backend.Api.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }
}
