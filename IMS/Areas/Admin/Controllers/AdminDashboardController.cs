using Microsoft.AspNetCore.Mvc;

namespace IMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
