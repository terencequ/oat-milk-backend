namespace OatMilk.Backend.Api.Modules.Shared.Domain.Models.Abstraction
{
    /// <summary>
    /// Interface for a request DTO with an ID field.
    /// </summary>
    public interface IUniqueRequest
    {
        string Id { get; set; }
    }
}