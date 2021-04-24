using Microsoft.AspNetCore.Mvc;
using System;
using OatMilk.Backend.Api.Services.Models.Enums;
using OatMilk.Backend.Api.Services.Models.Responses;

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
