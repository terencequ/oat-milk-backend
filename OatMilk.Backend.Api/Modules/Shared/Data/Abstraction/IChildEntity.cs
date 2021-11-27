namespace OatMilk.Backend.Api.Modules.Shared.Data.Abstraction
{
    /// <summary>
    /// Represents the child of a collection on an IEntity.
    /// </summary>
    public interface IChildEntity
    {
        string Id { get; set; }
        string Name { get; set; }
    }
}