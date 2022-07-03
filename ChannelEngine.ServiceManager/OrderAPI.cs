using ChannelEngine.ServiceManager.Interface;

namespace ChannelEngine.ServiceManager
{
    public class OrderAPI : IOrderAPI
    {
        HttpClient client = new HttpClient();

        public int GetOrderByID(int id)
        {
            GetOrderByParameter(ConstructOrderStatusRequest("IN_PROGRESS"));
            return id + 11;
        }

        private string ConstructOrderStatusRequest(string status)
        {
            return $"statuses={status}";
        }

        private async void GetOrderByParameter(string parameter)
        {
            /*
             * For example: https://api-dev.channelengine.net/api/v2/orders/new?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322
             */
            string path = $"https://demo.channelengine.net/api/v2/orders?statuses=IN_PROGRESS&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";


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

            // Deserialize the updated product from the response body.
           // product = await response.Content.ReadAsAsync<Product>();
           // return product;
        }
    }
}