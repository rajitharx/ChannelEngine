using ChannelEngine.Shared.Entity;

namespace ChannelEngine.ServiceManager.Interface
{
    public interface IProductAPI
    {
        Response<IList<MerchantProductResponse>> GetProductDetailsByFromAPI(string serachKey);
        ApiResponse<ProductCreationResult> UpsertProductUsing(IList<MerchantProductRequest> merchantProductRequests);

    }
}
