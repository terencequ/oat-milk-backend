using OatMilk.Backend.Api.Services.Models.Enums;

namespace OatMilk.Backend.Api.Services.Models.Responses
{
    /// <summary>
    /// Error DTO.
    /// Passed as a response when any error occurs.
    /// ErrorResponse is usually used as a base class for more specific error responses.
    /// </summary>
    public class ErrorResponse
    {
        public ErrorType ErrorType { get; set; }
        public string Message { get; set; }
    }
}
