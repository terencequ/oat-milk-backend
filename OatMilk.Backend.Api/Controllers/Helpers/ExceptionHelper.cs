using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Data.Models.Enums;
using System;
using OatMilk.Backend.Api.Data.Models.Responses;

namespace OatMilk.Backend.Api.Controllers.Helpers
{
    public static class ExceptionHelper
    {
        public static ActionResult ConvertExceptionToResult(Exception exception)
        {
            if (exception is ArgumentException argumentException)
            {
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
