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
            //// Initialize interface for InProgressService
            IInProgressService inProgressService = hosting.Services.GetService<IInProgressService>();
            IList<InProgressOrders> inProgressOrders = inProgressService.GetInProgressForTop5SellingProducts();

            //// Display Order details
            foreach (InProgressOrders orders in inProgressOrders)
            {
                Console.WriteLine(String.Format("GTIN: {0}, Name: {1}, Quantity: {2}",
                    orders.GTIN, orders.Name, orders.Quantity));
            }

            Console.WriteLine();
            Console.WriteLine(string.Format("Selecting a number between 0-{0}", inProgressOrders.Count - 1));

            //// randomly select record from the list.
            Random rnd = new Random();
            int numebr = rnd.Next(inProgressOrders.Count);

            string response = inProgressService.UpdateProduct(inProgressOrders[numebr].MerchantProductNo, 25);
        }
    }
}
