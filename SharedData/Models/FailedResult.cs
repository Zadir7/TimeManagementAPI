using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public record FailedResult : ServiceResult
    {
        private string Message { get; }

        public FailedResult(string message)
        {
            Message = message;
        }

        public override ActionResult AsActionResult() => 
            new ObjectResult(
                new ProblemDetails()
                {
                    Title = Message,
                    Status = (int)HttpStatusCode.InternalServerError
                });
    }
}