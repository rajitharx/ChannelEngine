using ChannelEngine.Shared.Entity;

namespace ChannelEngine.ServiceManager.Interface
{
    public interface IOrderAPI
    {
        Response<IList<MerchantOrderResponse>> GetOrderByStatusInProgress();
    }
}
