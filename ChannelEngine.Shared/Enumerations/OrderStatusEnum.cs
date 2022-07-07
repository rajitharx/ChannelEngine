namespace ChannelEngine.Shared.Enumerations
{
    /// <summary>
    /// Order Status
    /// </summary>
    public enum OrderStatusEnum
    {
        IN_PROGRESS, 
        SHIPPED, 
        IN_BACKORDER, 
        MANCO, 
        CANCELED, 
        IN_COMBI, 
        CLOSED, 
        NEW, 
        RETURNED, 
        REQUIRES_CORRECTION, 
        AWAITING_PAYMENT
    }
}
