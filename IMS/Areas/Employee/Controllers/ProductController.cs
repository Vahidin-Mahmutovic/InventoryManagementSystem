using IMS.DataAccess.Repository.IRepository;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,Unit").ToList();

            return View(productList);
        }
    }
}
