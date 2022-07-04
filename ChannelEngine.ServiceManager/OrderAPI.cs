using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ChannelEngine.ServiceManager
{
    public class OrderAPI : BaseServiceManager, IOrderAPI
    {
        HttpClient client = new HttpClient();
        private string ordersAPIURL = string.Empty;
        public OrderAPI(IConfiguration configuration) : base(configuration)
        {
            ordersAPIURL = string.Format("{0}{1}", apiURL, "orders");
        }

        public Response<IList<MerchantOrderResponse>> GetOrderByStatusInProgress()
        {
            string? statusStr = Enum.GetName(typeof(OrderStatusEnum), OrderStatusEnum.IN_PROGRESS);
            return GetOrderByParameter(ConstructOrderStatusRequest(statusStr))
                .GetAwaiter().GetResult();
        }

        private string ConstructOrderStatusRequest(string status)
        {
            return $"?statuses={status}";
        }

        private async Task<Response<IList<MerchantOrderResponse>>> GetOrderByParameter(string parameter)
        {
            Response<IList<MerchantOrderResponse>> responseObject = new Response<IList<MerchantOrderResponse>>();

            string path = ordersAPIURL+ $"{parameter}&apikey={apiKey}";
            
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