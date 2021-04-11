using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Requests
{
    public class UserRegisterRequest
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
