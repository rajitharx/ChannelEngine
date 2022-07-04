using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;

namespace ChannelEngine.BusinessService.Interface
{
    public interface IOrderService
    {
        IList<MerchantOrderResponse> GetAllOrdersByStatus(OrderStatusEnum orderStatusEnum);

        void GetTopSoldProductsByStatus(string status, int productCount);

        void UpdateProductStock(int merchantProductNo, int stockCount);
    }
}
