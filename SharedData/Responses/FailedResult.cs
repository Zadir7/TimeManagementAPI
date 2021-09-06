namespace SharedData.Responses
{
    public sealed record FailedResult
    {
        public int StatusCode { get; }
        public string Message { get; }

        public FailedResult(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}