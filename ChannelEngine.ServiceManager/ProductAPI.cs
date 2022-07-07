using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace ChannelEngine.ServiceManager
{
    public class ProductAPI : BaseServiceManager, IProductAPI
    {
        private HttpClient client = new HttpClient();
        private string productAPIURL = string.Empty;

        /// <summary>
        /// Constructor for ProductAPI
        /// </summary>
        /// <param name="configuration"></param>
        public ProductAPI(IConfiguration configuration) : base(configuration)
        {
            productAPIURL = string.Format("{0}{1}", apiURL, "products");
        }

        /// <summary>
        /// GetProductDetailsByFromAPI
        /// </summary>
        /// <param name="serachKey">String serachKey</param>
        /// <returns>List of MerchantProductResponse</returns>
        public Response<IList<MerchantProductResponse>> GetProductDetailsByFromAPI(string serachKey)
        {
            return GetProductBySearchKey(serachKey).GetAwaiter().GetResult();
        }

        /// <summary>
        /// UpsertProductUsing
        /// </summary>
        /// <param name="merchantProductRequests">List of MerchantProductRequest</param>
        /// <returns>ApiResponse</returns>
        public ApiResponse<ProductCreationResult> UpsertProductUsing(IList<MerchantProductRequest> merchantProductRequests)
        {
            return UpsertProduct(merchantProductRequests).GetAwaiter().GetResult();
        }

        /// <summary>
        /// UpsertProduct
        /// </summary>
        /// <param name="merchantProductRequests"></param>
        /// <returns>Response ProductCreationResult</returns>
        private async Task<ApiResponse<ProductCreationResult>> UpsertProduct(IList<MerchantProductRequest> merchantProductRequests)
        {
            ApiResponse<ProductCreationResult> apiResponse = new ApiResponse<ProductCreationResult>();
            var json = JsonConvert.SerializeObject(merchantProductRequests);
            string url = productAPIURL + $"?apikey={apiKey}";

            var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                apiResponse = JsonConvert.DeserializeObject<ApiResponse<ProductCreationResult>>(jsonString);
            }

            return apiResponse;
        }

        /// <summary>
        /// GetProductBySearchKey
        /// </summary>
        /// <param name="searchKey">string searchKey</param>
        /// <returns>MerchantProductResponse object</returns>
        private async Task<Response<IList<MerchantProductResponse>>> GetProductBySearchKey(string searchKey)
        {
            Response<IList<MerchantProductResponse>> responseObject = new Response<IList<MerchantProductResponse>>();

            string url = productAPIURL + $"?search={searchKey}&apikey={apiKey}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    responseObject = JsonConvert.DeserializeObject<Response<IList<MerchantProductResponse>>>(jsonString);
                }
            }
            catch
            {
                throw;
            }

            return responseObject;
        }
    }
}