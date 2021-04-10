using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Requests
{
    public class UserRegisterRequest
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
