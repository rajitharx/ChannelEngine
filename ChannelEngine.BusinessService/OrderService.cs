using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;
using System.Linq;

namespace ChannelEngine.BusinessService
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Interface for OrderAPI
        /// </summary>
        private readonly IOrderAPI _orderAPI;

        private readonly IProductService _productService;

        /// <summary>
        /// OrderService constructor
        /// </summary>
        /// <param name="orderAPI">IOrderAPI interface</param>
        public OrderService(IOrderAPI orderAPI, IProductService productService)
        {
            _orderAPI = orderAPI;
            _productService = productService;
        }

        public Response<IList<MerchantOrderResponse>> GetAllOrdersByStatus(OrderStatusEnum orderStatusEnum)
        {
            Response<IList<MerchantOrderResponse>> merchantOrderResponses = new();
            switch (orderStatusEnum)
            {
                case OrderStatusEnum.IN_PROGRESS:
                    {
                        merchantOrderResponses = GetAllOrdersByStatusFromAPI(orderStatusEnum);
                        break;
                    }
                default: break;
            }
            return merchantOrderResponses;
        }

        private Response<IList<MerchantOrderResponse>> GetAllOrdersByStatusFromAPI(OrderStatusEnum orderStatusEnum)
        {
            return _orderAPI.GetOrderByStatusInProgress();
           
        }

        //// TODO: add separate call to do the business login. 
        public void GetTopSoldProductsByStatus(IList<MerchantOrderLineResponse> merchantOrderLineResponses)
        {
            string stringVal = string.Empty;
            foreach (MerchantOrderLineResponse values in merchantOrderLineResponses)
            {
                stringVal += string.Format("{0}, {1}, {2}, {3}"
                    , values.MerchantProductNo
                    , values.Gtin
                    , values.JurisName
                    , values.Quantity) + "\n";
            }
            stringVal += "----------------------------------------" + "\n";
            merchantOrderLineResponses = merchantOrderLineResponses.OrderByDescending(x => x.Quantity).ToList();

            foreach (MerchantOrderLineResponse values in merchantOrderLineResponses)
            {
                Response<IList<MerchantProductResponse>> cval  = 
                    _productService.GetProductDetailsBySearchKey(values.MerchantProductNo);
            }
        }

        public void UpdateProductStock(int merchantProductNo, int stockCount)
        {
            throw new NotImplementedException();
        }
    }
}
