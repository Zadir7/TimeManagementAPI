using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public record FailedResult : ServiceResult, IActionResultConvertible
    {
        private string Message { get; }

        public FailedResult(string message)
        {
            Message = message;
        }

        public ActionResult AsActionResult() => 
            new ObjectResult(
                new ProblemDetails()
                {
                    Title = Message,
                    Status = (int)HttpStatusCode.InternalServerError
                });
    }
}