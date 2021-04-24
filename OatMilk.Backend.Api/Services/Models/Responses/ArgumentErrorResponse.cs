namespace OatMilk.Backend.Api.Services.Models.Responses
{
    /// <summary>
    /// Argument related error DTO.
    /// Passed as a response when an error has occured related to an request's arguments, 
    /// i.e. A certain resource couldn't be found due to a non-existing resource ID.
    /// </summary>
    public class ArgumentErrorResponse : ErrorResponse
    {
        public string Parameter { get; set; }
    }
}
