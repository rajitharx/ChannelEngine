using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;

namespace ChannelEngine.BusinessService.Interface
{
    public interface IOrderService
    {
        /// <summary>
        /// GetAllOrdersByStatus
        /// </summary>
        /// <param name="orderStatusEnum"></param>
        /// <returns>List of MerchantOrderResponse</returns>
        Response<IList<MerchantOrderResponse>> GetAllOrdersByStatus(OrderStatusEnum orderStatusEnum);

    }
}
