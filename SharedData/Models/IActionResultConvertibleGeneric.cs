using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public interface IActionResultConvertible<T>
    {
        public ActionResult<T> AsActionResult();
    }
}