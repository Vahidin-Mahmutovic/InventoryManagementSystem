using IMS.DataAccess.Repository.IRepository;
using IMS.Models.ViewModels;
using IMS.Services.IServices;
using IMS.Utility.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMS.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Employee")]
    public class InventoryTransactionController : Controller
    {
        private readonly IInventoryTransactionService _transactionService;
        private readonly IUnitOfWork _unitOfWork;

        public InventoryTransactionController(IInventoryTransactionService transactionService, IUnitOfWork unitOfWork)
        {
            _transactionService = transactionService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var transactions = _transactionService.GetAll();
            return View(transactions);
        }

        public IActionResult Create()
        {
            var vm = new InventoryTransactionVM
            {
                Products = _unitOfWork.Product.GetAll().Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }),
                Stores = _unitOfWork.Store.GetAll().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }),
                TransactionTypes = Enum.GetValues(typeof(TransactionType))
                    .Cast<TransactionType>()
                    .Select(t => new SelectListItem
                    {
                        Text = t.ToString(),
                        Value = t.ToString()
                    })
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InventoryTransactionVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Products = _unitOfWork.Product.GetAll().Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });

                vm.Stores = _unitOfWork.Store.GetAll().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });

                vm.TransactionTypes = Enum.GetValues(typeof(TransactionType))
                    .Cast<TransactionType>()
                    .Select(t => new SelectListItem
                    {
                        Text = t.ToString(),
                        Value = t.ToString()
                    });

                return View(vm);
            }

            if (vm.TransactionType == TransactionType.StockIn)
            {
                _transactionService.StockIn(vm.ProductId, vm.StoreId, vm.Quantity, vm.Note, vm.PerformedBy);
            }
            else if (vm.TransactionType == TransactionType.StockOut)
            {
                _transactionService.StockOut(vm.ProductId, vm.StoreId, vm.Quantity, vm.Note, vm.PerformedBy);
            }
            else
            {
                ModelState.AddModelError("", "Transfer is not supported yet.");
                return View(vm);
            }

            return RedirectToAction("Index");
        }
    }
}
