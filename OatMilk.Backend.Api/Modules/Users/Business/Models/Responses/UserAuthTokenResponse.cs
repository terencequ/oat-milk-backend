namespace OatMilk.Backend.Api.Modules.Users.Business.Models.Responses
{
    /// <summary>
    /// JWT Token DTO.
    /// Passed as a response when they login or register. 
    /// Will contain the JWT token that is used to authenticate with the backend.
    /// </summary>
    public class UserAuthTokenResponse
    {
        public string AuthToken { get; set; }
    }
}
