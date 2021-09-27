using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public interface IActionResultConvertible
    {
        public ActionResult AsActionResult();
    }
}