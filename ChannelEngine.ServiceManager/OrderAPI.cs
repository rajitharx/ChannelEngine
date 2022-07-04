using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using Microsoft.Extensions.Configuration;

namespace ChannelEngine.ServiceManager
{
    public class OrderAPI : IOrderAPI
    {
        private readonly IConfiguration _configuration;
        private string apiKey = string.Empty;
        HttpClient client = new HttpClient();

        public OrderAPI(IConfiguration configuration)
        {
            _configuration = configuration;
            apiKey = _configuration["AppSetting:APIKey"];
        }

        public IList<MerchantOrderResponse> GetOrderByStatusInProgress()
        {
            IList<MerchantOrderResponse> merchantOrderResponses = 
                GetOrderByParameter(ConstructOrderStatusRequest("IN_PROGRESS"), apiKey).GetAwaiter().GetResult(); ;
            return merchantOrderResponses;
        }

        private string ConstructOrderStatusRequest(string status)
        {
            return $"statuses={status}";
        }

        private async Task<IList<MerchantOrderResponse>> GetOrderByParameter(string parameter, string apiKey)
        {
            IList<MerchantOrderResponse> merchantOrderResponses = new List<MerchantOrderResponse>(); 
            string path = $"https://demo.channelengine.net/api/v2/orders?statuses=IN_PROGRESS&apikey={apiKey}";


            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    //  product = await response.Content.ReadAsAsync<Product>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return merchantOrderResponses;
        }
    }
}