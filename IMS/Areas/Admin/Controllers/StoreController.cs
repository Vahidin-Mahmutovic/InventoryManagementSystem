using IMS.DataAccess.Repository.IRepository;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public StoreController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }


        public ActionResult Index()
        {

           List<Store> objStoreList = _unitOfWork.Store.GetAll().ToList();
            return View(objStoreList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Store obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Store.Add(obj);
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

            Store? storeFromDb = _unitOfWork.Store.Get(u => u.Id == id);

            if (storeFromDb == null)
            {

                return NotFound();

            }
            return View(storeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Store obj)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Store.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id) {
            
            if(id == null || id == 0)
            {
                return NotFound();
            }

            Store storeFromDb = _unitOfWork.Store.Get(u => u.Id == id);

            if(storeFromDb == null)
            {
                return NotFound();
            }

            return View(storeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            Store? obj = _unitOfWork.Store.Get(u=>u.Id ==  id);

            if(obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Store.Delete(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
