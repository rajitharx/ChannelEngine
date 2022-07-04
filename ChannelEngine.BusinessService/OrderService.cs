using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;

namespace ChannelEngine.BusinessService
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Interface for OrderAPI
        /// </summary>
        private readonly IOrderAPI _orderAPI;

        /// <summary>
        /// OrderService constructor
        /// </summary>
        /// <param name="orderAPI">IOrderAPI interface</param>
        public OrderService(IOrderAPI orderAPI)
        {
            _orderAPI = orderAPI;
        }

        public IList<MerchantOrderResponse> GetAllOrdersByStatus(OrderStatusEnum orderStatusEnum)
        {
            switch (orderStatusEnum)
            {
                case OrderStatusEnum.IN_PROGRESS:
                    {
                        // your code 
                        // for plus operator
                        break;
                    }
                default: break;
            }
            throw new NotImplementedException();
        }

        private IList<MerchantOrderResponse> GetAllOrdersByStatusFromAPI(OrderStatusEnum orderStatusEnum)
        {
            string? statusStr = Enum.GetName(typeof(OrderStatusEnum), orderStatusEnum);

            IList<MerchantOrderResponse> merchantOrderResponses =
                _orderAPI.GetOrderByStatusInProgress();
            throw new NotImplementedException();
        }

        public void GetTopSoldProductsByStatus(string status, int productCount)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductStock(int merchantProductNo, int stockCount)
        {
            throw new NotImplementedException();
        }
    }
}
