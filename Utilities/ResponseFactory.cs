using System.Net;
using Microsoft.AspNetCore.Mvc;
using SharedData.Locale;
using SharedData.Responses;

namespace Utilities
{
    public static class ResponseFactory
    {
        public static ObjectResult FailResponse(string message) => 
            new ObjectResult(
                new FailedResult(
                    (int)HttpStatusCode.InternalServerError, 
                    message
                )
            );
    }
}