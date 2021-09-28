using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public abstract record ServiceResult<T>
    {
        public abstract ActionResult<T> AsActionResult();
    }
}