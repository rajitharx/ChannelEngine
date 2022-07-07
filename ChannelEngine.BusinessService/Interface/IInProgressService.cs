using ChannelEngine.Shared.Entity;

namespace ChannelEngine.BusinessService.Interface
{
    public interface IInProgressService
    {
        /// <summary>
        /// GetInProgressForTop5SellingProducts
        /// </summary>
        /// <returns>List of InProgressOrders</returns>
        IList<InProgressOrders> GetInProgressForTop5SellingProducts();

        /// <summary>
        /// UpdateProduct
        /// </summary>
        /// <param name="merchantProductNo">string merchantProductNo</param>
        /// <param name="stock">int stock</param>
        /// <returns>string response message</returns>
        string UpdateProduct(string merchantProductNo, int stock);
    }
}