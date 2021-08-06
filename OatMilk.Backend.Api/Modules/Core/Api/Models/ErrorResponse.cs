using System;

namespace OatMilk.Backend.Api.Modules.Core.Api.Models
{
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ErrorResponse(Exception ex, bool hideStackTrace = true)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = hideStackTrace ? "" : ex.ToString();
        }
    }
}