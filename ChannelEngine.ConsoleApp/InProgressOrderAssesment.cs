using ChannelEngine.BusinessService.Interface;
using ChannelEngine.Shared.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChannelEngine.ConsoleApp
{
    internal static class InProgressOrderAssesment
    {
        /// <summary>
        /// ExecuteAssesment
        /// </summary>
        /// <param name="hosting"></param>
        public static void ExecuteAssesment(IHost hosting)
        {
            IInProgressService orderService = hosting.Services.GetService<IInProgressService>();
            IList<InProgressOrders> inProgressOrders = orderService.GetInProgressForTop5SellingProducts();

            foreach (InProgressOrders orders in inProgressOrders)
            {
                Console.WriteLine(String.Format("GTIN: {0}, Name: {1}, Quantity: {2}", 
                    orders.GTIN, orders.Name, orders.Quantity));
            }
        }
    }
}
