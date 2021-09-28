using Microsoft.AspNetCore.Mvc;

namespace SharedData.Models
{
    public sealed record SuccessfulResult<T> : ServiceResult<T>
    {
        public T Data { get; }

        public SuccessfulResult(T data)
        {
            Data = data;
        }

        public override ActionResult<T> AsActionResult() =>
            new ObjectResult(Data);
    }
}