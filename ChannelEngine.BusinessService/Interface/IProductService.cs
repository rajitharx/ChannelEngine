using ChannelEngine.Shared.Entity;

namespace ChannelEngine.BusinessService.Interface
{
    public interface IProductService
    {
        Response<IList<MerchantProductResponse>> GetProductDetailsBySearchKey(string searchKey);
    }
}
