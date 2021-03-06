namespace OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction
{
    /// <summary>
    /// Interface for a request DTO with a name field.
    /// </summary>
    public interface INamedRequest
    {
        string Name { get; set; }
    }
}