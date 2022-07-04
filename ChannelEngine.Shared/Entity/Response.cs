namespace ChannelEngine.Shared.Entity
{
    public class Response<T>
    {
        public T Content {get; set;}
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public string RequestId { get; set; }
        public string LogId { get; set; }
        public string SuccessMessage { get; set; }
        public object ValidationErrors { get; set; }

    }
}
