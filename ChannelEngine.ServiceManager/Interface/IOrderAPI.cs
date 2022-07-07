using ChannelEngine.Shared.Entity;

namespace ChannelEngine.ServiceManager.Interface
{
    public interface IOrderAPI
    {
        /// <summary>
        /// GetOrderByStatusInProgress
        /// </summary>
        /// <returns>List of MerchantOrderResponse object</returns>
        Response<IList<MerchantOrderResponse>> GetOrderByStatusInProgress();
    }
}