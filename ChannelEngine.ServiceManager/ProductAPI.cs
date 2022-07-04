using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.ServiceManager
{
    public class ProductAPI : BaseServiceManager, IProductAPI
    {
        HttpClient client = new HttpClient();
        private string productAPIURL = string.Empty;
        public ProductAPI(IConfiguration configuration) : base(configuration)
        {
            productAPIURL = string.Format("{0}{1}", apiURL, "orders");
        }

        public Response<IList<MerchantProductResponse>> GetProductDetailsByFromAPI(string serachKey)
        {
            return GetProductBySearchKey(serachKey).GetAwaiter().GetResult(); ;
        }

        private async Task<Response<IList<MerchantProductResponse>>> GetProductBySearchKey(string searchKey)
        {
            Response<IList<MerchantProductResponse>> responseObject = new Response<IList<MerchantProductResponse>>();

            string path = productAPIURL + $"?search={searchKey}&apikey={apiKey}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    responseObject = JsonConvert.DeserializeObject<Response<IList<MerchantProductResponse>>>(jsonString);
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
