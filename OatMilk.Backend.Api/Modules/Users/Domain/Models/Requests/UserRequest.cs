using System.ComponentModel.DataAnnotations;

namespace OatMilk.Backend.Api.Modules.Users.Domain.Models.Requests
{
    public class UserRequest
    {
        [Required]
        [MinLength(4, ErrorMessage = "Too short. Minimum length is 4.")]
        [MaxLength(20, ErrorMessage = "Too long. Maximum length is 20.")]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$", ErrorMessage = "Minimum eight characters, at least one letter and one number required.")]
        public string Password { get; set; }
    }
}
