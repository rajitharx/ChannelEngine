using ChannelEngine.BusinessService.Interface;
using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;

namespace ChannelEngine.BusinessService
{
    public class InProgressService : IInProgressService
    {
        /// <summary>
        /// Interface for OrderService
        /// </summary>
        private readonly IOrderService _orderService;

        /// <summary>
        /// Interface for ProductService
        /// </summary>
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor for InProgressService
        /// </summary>
        /// <param name="orderService">IOrderService</param>
        /// <param name="productService">IProductService</param>
        public InProgressService(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public InProgressOrders GetInProgressForTop5SellingProducts()
        {
            Response<IList<MerchantOrderResponse>> response =
                GetAllOrdersByStatus(OrderStatusEnum.IN_PROGRESS);
            IList<MerchantOrderLineResponse> merchantOrderLineResponses =
                GetTop5SellingProductFromMerchantOrderResponses(response.Content);
            IList<InProgressOrders> inProgressOrders = 
                GetInProgressOrdersProductDetails(merchantOrderLineResponses);

            throw new NotImplementedException();
        }

        /// <summary>
        /// GetAllOrdersByStatus
        /// </summary>
        /// <param name="orderStatusEnum">OrderStatusEnum</param>
        /// <returns>Response object with MerchantOrderResponse</returns>
        private Response<IList<MerchantOrderResponse>> GetAllOrdersByStatus(OrderStatusEnum orderStatusEnum)
        {
            return _orderService.GetAllOrdersByStatus(orderStatusEnum);
        }

        /// <summary>
        /// GetProductDetailsBySearchKey
        /// </summary>
        /// <param name="searchKey">string searchKey</param>
        /// <returns>Response with list of MerchantProductResponse</returns>
        private Response<IList<MerchantProductResponse>> GetProductDetailsBySearchKey(string searchKey)
        {
            return _productService.GetProductDetailsBySearchKey(searchKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantOrderLineResponses"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private IList<InProgressOrders> GetInProgressOrdersProductDetails
            (IList<MerchantOrderLineResponse> merchantOrderLineResponses)
        {
            IList<InProgressOrders> inProgressOrders = new List<InProgressOrders>();
            foreach (MerchantOrderLineResponse merchantOrderLineResponse in merchantOrderLineResponses)
            {
                Response<IList<MerchantProductResponse>> response =
                    GetProductDetailsBySearchKey(merchantOrderLineResponse.MerchantProductNo);

                if (response == null) throw new ArgumentNullException(nameof(response));

                InProgressOrders inProgressOrder = new InProgressOrders
                {
                    Name = response.Content[0].Name,
                    GTIN = merchantOrderLineResponse.Gtin,
                    Quantity = merchantOrderLineResponse.Quantity
                };

                inProgressOrders.Add(inProgressOrder);
            }

            return inProgressOrders;
        }

        /// <summary>
        /// GetTop5SellingProductFromMerchantOrderResponses
        /// </summary>
        /// <param name="merchantOrderResponses">list of MerchantOrderResponse</param>
        /// <returns>List of MerchantOrderLineResponse</returns>
        private IList<MerchantOrderLineResponse> GetTop5SellingProductFromMerchantOrderResponses
            (IList<MerchantOrderResponse> merchantOrderResponses)
        {
            IList<MerchantOrderLineResponse> merchantOrderLineResponses = new List<MerchantOrderLineResponse>();

            foreach (MerchantOrderResponse merchantOrderResponse in merchantOrderResponses)
            {
                foreach (MerchantOrderLineResponse merchantOrderLineResponse in merchantOrderResponse.Lines)
                {
                    merchantOrderLineResponses.Add(merchantOrderLineResponse);
                }
            }

            merchantOrderLineResponses = merchantOrderLineResponses
                .OrderByDescending(x => x.Quantity).Take(5).ToList();

            return merchantOrderLineResponses;
        }
    }
}