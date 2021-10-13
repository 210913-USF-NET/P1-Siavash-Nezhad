using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLogic;
using Models;
using DL;

namespace WebUI.Controllers
{
    public class StoreFrontController : Controller
    {
        private IBL _bl;
        public StoreFrontController(IBL bl)
        {
            _bl = bl;
        }
        // GET: StoreController
        public ActionResult Index()
        {
            List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
            return View(allStoreFronts);
        }

        // GET: StoreController/Details/5
        public ActionResult ViewInventory(int id)
        {
            ViewBag.Stock = _bl.GetInventory(id);
            ViewBag.ProductInfo = _bl.GetAllProducts();
            return View();
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
