using ChannelEngine.BusinessService.Interface;
using ChannelEngine.Shared.Entity;
using ChannelEngine.Shared.Enumerations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.UnitTest.MockObjects
{
    public  class MockIOrderService : Mock<IOrderService>
    {
        public Response<IList<MerchantOrderResponse>> GetAllOrdersByStatus(OrderStatusEnum orderStatusEnum)
        {
            throw new NotImplementedException();
        }
    }
}
