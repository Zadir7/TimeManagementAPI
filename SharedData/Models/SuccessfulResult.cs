using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public record SuccessfulResult : ServiceResult
    {
        public override ActionResult AsActionResult() =>
            new OkResult();
    }
}