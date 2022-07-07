namespace ChannelEngine.Shared.Entity
{
    public class ApiResponse<T>
    {
        public T Content {get; set;}
        public int StatusCode { get; set; }
        public string RequestId { get; set; }
        public string LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object ValidationErrors { get; set; }

    }
}
