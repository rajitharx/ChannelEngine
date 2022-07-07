namespace ChannelEngine.Shared.Entity
{
    public class ProductCreationResult
    {
        public int RejectedCount { get; set; }
        public int AcceptedCount { get; set; }
        public IList<ProductMessage> ProductMessages { get; set; }
    }
}
