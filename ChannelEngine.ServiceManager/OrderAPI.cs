using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ChannelEngine.ServiceManager
{
    public class OrderAPI : BaseServiceManager, IOrderAPI
    {
        private HttpClient client = new HttpClient();
        private string ordersAPIURL = string.Empty;

        /// <summary>
        /// Constructor for OrderAPI
        /// </summary>
        /// <param name="configuration"></param>
        public OrderAPI(IConfiguration configuration) : base(configuration)
        {
            ordersAPIURL = string.Format("{0}{1}", apiURL, "orders");
        }

        /// <summary>
        /// GetOrderByStatusInProgress
        /// </summary>
        /// <returns>List of MerchantOrderResponse object</returns>
        public Response<IList<MerchantOrderResponse>> GetOrderByStatusInProgress()
        {
            string? statusStr = Enum.GetName(typeof(OrderStatusEnum), OrderStatusEnum.IN_PROGRESS);
            return GetOrderByParameter(ConstructOrderStatusRequest(statusStr))
                .GetAwaiter().GetResult();
        }

        /// <summary>
        /// ConstructOrderStatusRequest
        /// </summary>
        /// <param name="status"></param>
        /// <returns>String URL</returns>
        private string ConstructOrderStatusRequest(string status)
        {
            return $"?statuses={status}";
        }

        /// <summary>
        /// GetOrderByParameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>List of MerchantOrderResponse</returns>
        private async Task<Response<IList<MerchantOrderResponse>>> GetOrderByParameter(string parameter)
        {
            Response<IList<MerchantOrderResponse>> responseObject = new Response<IList<MerchantOrderResponse>>();

            string path = ordersAPIURL + $"{parameter}&apikey={apiKey}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    responseObject = JsonConvert.DeserializeObject<Response<IList<MerchantOrderResponse>>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return responseObject;
        }
    }
}