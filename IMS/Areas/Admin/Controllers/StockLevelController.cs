using IMS.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockLevelController : Controller
    {
        private readonly IStockLevelService _stockLevelService;

        public StockLevelController(IStockLevelService stockLevelService)
        {
            _stockLevelService = stockLevelService;
        }

        public IActionResult Index()
        {
            var stockLevels = _stockLevelService.GetAll();
            return View(stockLevels);
        }
    }
}
