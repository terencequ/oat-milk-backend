namespace OatMilk.Backend.Api.Modules.Users.Business.Models.Responses
{
    /// <summary>
    /// User DTO.
    /// Passed as a response when a user's details are requested.
    /// </summary>
    public class UserResponse
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
