using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Data.Models.Responses.Errors
{
    public class ArgumentErrorResponse : ErrorResponse
    {
        public string Parameter { get; set; }
    }
}
