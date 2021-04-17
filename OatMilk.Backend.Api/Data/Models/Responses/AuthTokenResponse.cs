using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Responses
{
    /// <summary>
    /// JWT Token DTO.
    /// Passed as a response when they login or register. 
    /// Will contain the JWT token that is used to authenticate with the backend.
    /// </summary>
    public class AuthTokenResponse
    {
        public string AuthToken { get; set; }
    }
}
