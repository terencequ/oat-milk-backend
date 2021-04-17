using OatMilk.Backend.Api.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Responses
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
