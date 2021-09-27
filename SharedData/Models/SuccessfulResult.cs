using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public record SuccessfulResult : ServiceResult, IActionResultConvertible
    {
        public ActionResult AsActionResult() =>
            new OkResult();
    }
}