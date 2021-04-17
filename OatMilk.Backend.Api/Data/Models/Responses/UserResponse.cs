using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Responses
{
    /// <summary>
    /// User DTO.
    /// Passed as a response when a user's details are requested.
    /// </summary>
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
