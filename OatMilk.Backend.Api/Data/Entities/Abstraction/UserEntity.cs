namespace OatMilk.Backend.Api.Data.Entities.Abstraction
{
    public abstract class UserEntity : AuditableEntity
    {
        public User User { get; set; }
    }
}