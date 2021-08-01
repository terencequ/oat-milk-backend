using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OatMilk.Backend.Api.Controllers.Models;

namespace OatMilk.Backend.Api.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; // Your exception
            var code = 500; // Internal Server Error by default

            if (exception is ArgumentException) code = 400; // Not Found

            Response.StatusCode = code; // You can use HttpStatusCode enum instead

            var shouldHideStackTrace = webHostEnvironment.EnvironmentName != "Development";
            return new ErrorResponse(exception, shouldHideStackTrace); // Your error model
        }
    }
}