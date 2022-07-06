using ChannelEngine.BusinessService.Interface;
using ChannelEngine.Shared.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInProgressService _inProgressService;

        public HomeController(ILogger<HomeController> logger, IInProgressService inProgressService)
        {
            _logger = logger;
            _inProgressService = inProgressService;
        }

        public IActionResult Index()
        {
            IList<InProgressOrders> inProgressOrders = _inProgressService.GetInProgressForTop5SellingProducts();
            return View(inProgressOrders);
        }

        public IActionResult UpdateStockUsingMerchantProductNo(string merchantProductNo)
        {
            string response = _inProgressService.UpdateProduct(merchantProductNo, 25);
            return new JsonResult(new { isSuccess = true, message = response });
        }
    }
}