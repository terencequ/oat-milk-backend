using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    /// <summary>
    /// Character attribute response DTO.
    /// </summary>
    public class CharacterAttributeResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int CurrentValue { get; set; }
        [Required] public int DefaultValue { get; set; }
    }
}