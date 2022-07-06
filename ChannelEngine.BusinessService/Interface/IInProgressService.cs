using ChannelEngine.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.BusinessService.Interface
{
    public interface IInProgressService
    {

        IList<InProgressOrders> GetInProgressForTop5SellingProducts();
        string UpdateProduct(string merchantProductNo, int stock);
    }
}
