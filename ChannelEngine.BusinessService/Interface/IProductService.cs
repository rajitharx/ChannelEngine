using ChannelEngine.Shared.Entity;

namespace ChannelEngine.BusinessService.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// GetProductDetailsBySearchKey
        /// </summary>
        /// <param name="searchKey">String searchKey</param>
        /// <returns>List of MerchantProductResponse</returns>
        Response<IList<MerchantProductResponse>> GetProductDetailsBySearchKey(string searchKey);

        /// <summary>
        /// UpsertProduct
        /// </summary>
        /// <param name="merchantProductRequest"></param>
        /// <returns>ProductCreationResult object</returns>
        ApiResponse<ProductCreationResult> UpsertProduct(IList<MerchantProductRequest> merchantProductRequest);
    }
}
