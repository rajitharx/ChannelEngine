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
        /// interface for IProductService
        /// </summary>
        private readonly IProductService _productService;

        /// <summary>
        /// OrderService constructor
        /// </summary>
        /// <param name="orderAPI"></param>
        /// <param name="productService"></param>
        public OrderService(IOrderAPI orderAPI, IProductService productService)
        {
            _orderAPI = orderAPI;
            _productService = productService;
        }

        /// <summary>
        /// GetAllOrdersByStatus
        /// </summary>
        /// <param name="orderStatusEnum">OrderStatusEnum</param>
        /// <returns>List of MerchantOrderResponse</returns>
        public Response<IList<MerchantOrderResponse>> GetAllOrdersByStatus(OrderStatusEnum orderStatusEnum)
        {
            Response<IList<MerchantOrderResponse>> merchantOrderResponses = new();
            switch (orderStatusEnum)
            {
                //// Possible to implement for more status
                case OrderStatusEnum.IN_PROGRESS:
                    {
                        merchantOrderResponses = GetAllOrdersByStatusFromAPI(orderStatusEnum);
                        break;
                    }
                default: break;
            }
            return merchantOrderResponses;
        }

        /// <summary>
        /// GetAllOrdersByStatusFromAPI
        /// </summary>
        /// <param name="orderStatusEnum"></param>
        /// <returns>List of MerchantOrderResponse</returns>
        private Response<IList<MerchantOrderResponse>> GetAllOrdersByStatusFromAPI(OrderStatusEnum orderStatusEnum)
        {
            return _orderAPI.GetOrderByStatusInProgress();
        }
    }
}