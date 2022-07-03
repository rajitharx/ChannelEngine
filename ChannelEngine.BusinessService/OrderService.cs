using ChannelEngine.BusinessService.Interface;
using ChannelEngine.ServiceManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.BusinessService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderAPI _orderAPI;

        public OrderService(IOrderAPI orderAPI)
        {
            _orderAPI = orderAPI;
        }

        public int GetOrderByID(int id)
        {
            return _orderAPI.GetOrderByID(id);
        }
    }
}
