using Microsoft.AspNetCore.Mvc;

namespace IMS.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeDashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
