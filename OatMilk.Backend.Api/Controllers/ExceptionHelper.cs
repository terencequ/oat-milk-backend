using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Data.Models.Enums;
using OatMilk.Backend.Api.Data.Models.Responses.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OatMilk.Backend.Api.Controllers
{
    public class ExceptionHelper
    {
        public static ActionResult ConvertExceptionToResult(Exception exception)
        {
            if (exception is ArgumentException)
            {
                var argumentException = (ArgumentException)exception;
                return new BadRequestObjectResult(new ArgumentErrorResponse()
                {
                    ErrorType = ErrorType.ArgumentError,
                    Message = argumentException.Message,
                    Parameter = argumentException.ParamName
                });
            }
            else
            {
                throw exception;
            }
        }
    }
}
