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

        public Response<IList<MerchantProductResponse>> GetProductDetailsBySearchKey(string searchKey)
        {
            return _productAPI.GetProductDetailsByFromAPI(searchKey);
        }

        public ApiResponse<ProductCreationResult> UpsertProduct(IList<MerchantProductRequest> merchantProductRequests)
        {
            return _productAPI.UpsertProductUsing(merchantProductRequests);
        }
    }
}