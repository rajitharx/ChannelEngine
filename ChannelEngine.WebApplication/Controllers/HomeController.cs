using ChannelEngine.BusinessService.Interface;
using ChannelEngine.Shared.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInProgressService _inProgressService;

        /// <summary>
        /// Constructor for HomeController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="inProgressService">IInProgressService</param>
        public HomeController(ILogger<HomeController> logger, IInProgressService inProgressService)
        {
            _logger = logger;
            _inProgressService = inProgressService;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns>IActionResult</returns>
        public IActionResult Index()
        {
            IList<InProgressOrders> inProgressOrders = _inProgressService.GetInProgressForTop5SellingProducts();
            return View(inProgressOrders);
        }

        /// <summary>
        /// UpdateStockUsingMerchantProductNo
        /// </summary>
        /// <param name="merchantProductNo">string merchantProductNo</param>
        /// <returns>IActionResult</returns>
        public IActionResult UpdateStockUsingMerchantProductNo(string merchantProductNo)
        {
            string response = _inProgressService.UpdateProduct(merchantProductNo, 25);
            return new JsonResult(new { isSuccess = true, message = response });
        }
    }
}