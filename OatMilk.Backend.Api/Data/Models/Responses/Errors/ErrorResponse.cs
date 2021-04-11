using OatMilk.Backend.Api.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Responses.Errors
{
    public class ErrorResponse
    {
        public ErrorType ErrorType { get; set; }
        public string Message { get; set; }
    }
}
