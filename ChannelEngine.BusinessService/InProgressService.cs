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

        /// <summary>
        /// GetInProgressForTop5SellingProducts
        /// </summary>
        /// <returns>InProgressOrders object list</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IList<InProgressOrders> GetInProgressForTop5SellingProducts()
        {
            Response<IList<MerchantOrderResponse>> listOfMerchantOrderResponse =
                GetAllOrdersByStatus(OrderStatusEnum.IN_PROGRESS);

            if (listOfMerchantOrderResponse == null)
                throw new ArgumentNullException(nameof(listOfMerchantOrderResponse));

            IList<MerchantOrderLineResponse> merchantOrderLineResponses =
                GetTop5SellingProductFromMerchantOrderResponses(listOfMerchantOrderResponse.Content);

            if (merchantOrderLineResponses == null)
                throw new ArgumentNullException(nameof(merchantOrderLineResponses));

            IList<InProgressOrders> inProgressOrders =
                GetInProgressOrdersProductDetails(merchantOrderLineResponses);

            return inProgressOrders ?? throw new ArgumentNullException(nameof(inProgressOrders));
        }

        public string UpdateProduct(string merchantProductNo, int stock)
        {
            string responseStr = string.Empty;
            Response<IList<MerchantProductResponse>> listOfMerchantProductResponse =
                GetProductDetailsBySearchKey(merchantProductNo);
            if (listOfMerchantProductResponse.Content == null)
                throw new ArgumentNullException(nameof(listOfMerchantProductResponse.Content));

            MerchantProductRequest merchantProductRequest =
                PopulateMerchantProductRequestByMerchantProductResponse(listOfMerchantProductResponse.Content[0]);
            merchantProductRequest.Stock = stock;

            IList<MerchantProductRequest> merchantProductRequests = new List<MerchantProductRequest>
            {
                merchantProductRequest
            };

            ApiResponse<ProductCreationResult> productCreationResult = _productService.UpsertProduct(merchantProductRequests);

            if (productCreationResult.StatusCode == 200)
            {
                responseStr = string.Format("{0} record(s) updated successfully!", productCreationResult.Content.AcceptedCount);
            }
            else
            {
                responseStr = productCreationResult.Message;
            }

           return responseStr;
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

                if (response.Content == null) throw new ArgumentNullException(nameof(response.Content));

                InProgressOrders inProgressOrder = new InProgressOrders
                {
                    Name = response.Content[0].Name,
                    GTIN = merchantOrderLineResponse.Gtin,
                    Quantity = merchantOrderLineResponse.Quantity,
                    MerchantProductNo = merchantOrderLineResponse.MerchantProductNo,
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

            //// Take top 5 products
            merchantOrderLineResponses = merchantOrderLineResponses
                .OrderByDescending(x => x.Quantity).Take(5).ToList();

            return merchantOrderLineResponses;
        }

        private MerchantProductRequest PopulateMerchantProductRequestByMerchantProductResponse(MerchantProductResponse merchantProductResponse)
        {
            MerchantProductRequest merchantProductRequest = new MerchantProductRequest
            {
                ParentMerchantProductNo = String.Empty,
                ParentMerchantProductNo2 = String.Empty,
                ExtraData = merchantProductResponse.ExtraData,
                Name = merchantProductResponse.Name,
                Description = merchantProductResponse.Description,
                Brand = merchantProductResponse.Brand,
                Size = merchantProductResponse.Size,
                Color = merchantProductResponse.Color,
                Ean = merchantProductResponse.Ean,
                ManufacturerProductNumber = merchantProductResponse.ManufacturerProductNumber,
                MerchantProductNo = merchantProductResponse.MerchantProductNo,
                Stock = merchantProductResponse.Stock,
                Price = merchantProductResponse.Price,
                MSRP = merchantProductResponse.MSRP,
                PurchasePrice = merchantProductResponse.PurchasePrice,
                VatRateType = merchantProductResponse.VatRateType,
                ShippingCost = merchantProductResponse.ShippingCost,
                ShippingTime = merchantProductResponse.ShippingTime,
                Url = merchantProductResponse.Url,
                ImageUrl = merchantProductResponse.ImageUrl,
                ExtraImageUrl1 = merchantProductResponse.ExtraImageUrl1,
                ExtraImageUrl2 = merchantProductResponse.ExtraImageUrl2,
                ExtraImageUrl3 = merchantProductResponse.ExtraImageUrl3,
                ExtraImageUrl4 = merchantProductResponse.ExtraImageUrl4,
                ExtraImageUrl5 = merchantProductResponse.ExtraImageUrl5,
                ExtraImageUrl6 = merchantProductResponse.ExtraImageUrl6,
                ExtraImageUrl7 = merchantProductResponse.ExtraImageUrl7,
                ExtraImageUrl8 = merchantProductResponse.ExtraImageUrl8,
                ExtraImageUrl9 = merchantProductResponse.ExtraImageUrl9,
                CategoryTrail = merchantProductResponse.CategoryTrail
            };

            return merchantProductRequest;
        }
    }
}