using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public sealed record FailedResult<T> : ServiceResult<T>, IActionResultConvertible<T>
    {
        private string Message { get; }

        public FailedResult(string message)
        {
            Message = message;
        }

        public ActionResult<T> AsActionResult() => 
            new ObjectResult(
                new ProblemDetails()
                {
                    Title = Message,
                    Status = (int)HttpStatusCode.InternalServerError
                });
    }
}