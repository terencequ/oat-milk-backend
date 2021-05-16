﻿namespace OatMilk.Backend.Api.Services.Models.Responses
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
