using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
