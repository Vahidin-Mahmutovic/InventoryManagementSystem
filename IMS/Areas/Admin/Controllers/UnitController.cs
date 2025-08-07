using IMS.DataAccess.Repository.IRepository;
using IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UnitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            List<Unit> objUnitsList = _unitOfWork.Unit.GetAll().ToList();
            return View(objUnitsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Unit obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Unit.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Unit? unitFromDb = _unitOfWork.Unit.Get(u => u.Id == id);
            if (unitFromDb == null)
            {

                return NotFound();
            }

            return View(unitFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Unit obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Unit.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Unit? unitFromDb = _unitOfWork.Unit.Get(u => u.Id == id);

            if (unitFromDb == null)
            {
                return NotFound();
            }

            return View(unitFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            Unit? obj = _unitOfWork.Unit.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Unit.Delete(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}