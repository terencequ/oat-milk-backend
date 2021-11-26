using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Users.Domain.Models.Requests
{
    public class UserLoginRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
