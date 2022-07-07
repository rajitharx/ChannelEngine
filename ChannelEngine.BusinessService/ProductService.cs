using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;

namespace ChannelEngine.BusinessService
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Interface for ProductAPI
        /// </summary>
        private readonly IProductAPI _productAPI;

        /// <summary>
        /// ProductService Constructor
        /// </summary>
        /// <param name="productAPI"></param>
        public ProductService(IProductAPI productAPI)
        {
            _productAPI = productAPI;
        }

        /// <summary>
        /// GetProductDetailsBySearchKey
        /// </summary>
        /// <param name="searchKey">string searchKey</param>
        /// <returns>List of MerchantProductResponse</returns>
        public Response<IList<MerchantProductResponse>> GetProductDetailsBySearchKey(string searchKey)
        {
            return _productAPI.GetProductDetailsByFromAPI(searchKey);
        }

        /// <summary>
        /// UpsertProduct
        /// </summary>
        /// <param name="merchantProductRequests">List of MerchantProductRequest</param>
        /// <returns>ProductCreationResult object</returns>
        public ApiResponse<ProductCreationResult> UpsertProduct(IList<MerchantProductRequest> merchantProductRequests)
        {
            return _productAPI.UpsertProductUsing(merchantProductRequests);
        }
    }
}