using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager.Interface;
using ChannelEngine.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.BusinessService
{
    public class ProductService : IProductService
    {
        private readonly IProductAPI _productAPI;
        public Response<MerchantProductResponse> GetProductDetailsBy(string serach)
        {
            throw new NotImplementedException();
        }
    }
}
