using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public abstract record ServiceResult
    {
        public abstract ActionResult AsActionResult();
    }
}