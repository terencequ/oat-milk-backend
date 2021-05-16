namespace OatMilk.Backend.Api.Data.Entities.Abstraction
{
    public abstract class UserEntity : AuditableEntity
    {
        /// <summary>
        /// This will be used as an ID that will be enforced on a user level.
        /// </summary>
        public string Name { get; set; }
        public User User { get; set; }
    }
}