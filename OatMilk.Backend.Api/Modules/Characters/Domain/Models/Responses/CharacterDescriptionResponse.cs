using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Characters.Domain.Models.Responses
{
    /// <summary>
    /// Character description response model.
    /// </summary>
    public class CharacterDescriptionResponse
    {
        [Required] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Value { get; set; }
    }
}