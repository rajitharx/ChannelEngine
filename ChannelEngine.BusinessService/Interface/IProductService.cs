using ChannelEngine.Shared.Entity;

namespace ChannelEngine.BusinessService.Interface
{
    public interface IProductService
    {
        Response<MerchantProductResponse> GetProductDetailsBy(string serach);
    }
}
