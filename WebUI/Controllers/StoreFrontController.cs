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
        public ActionResult NewLineItem()
        {
            Response.Cookies.Delete("ProductID");
            Response.Cookies.Delete("DiscFormat");
            Response.Cookies.Delete("DiscCap");
            Response.Cookies.Delete("Color");
            Response.Cookies.Delete("StoreID");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetProduct(string StoreID)
        {
            if (Request.Cookies["StoreID"] != null)
            {
                Response.Cookies.Delete("StoreID");
            }
            Response.Cookies.Append("StoreID", StoreID);
            return View("GetProduct");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewLineItem(string DiscFormat, string DiscCap, string Color)
        {
            if (Request.Cookies["ProductID"] != null)
            {
                Response.Cookies.Delete("ProductID");
                Response.Cookies.Delete("DiscFormat");
                Response.Cookies.Delete("DiscCap");
                Response.Cookies.Delete("Color");
            }
            Response.Cookies.Append("DiscFormat", DiscFormat);
            Response.Cookies.Append("DiscCap", DiscCap);
            Response.Cookies.Append("Color", Color);
            int newDiscCap = Int32.Parse(DiscCap);
            Product thisProduct = _bl.GetProduct(DiscFormat, newDiscCap, Color);
                Response.Cookies.Append("ProductID", thisProduct.ProductID.ToString());
            Response.Cookies.Delete("Quantity");
            return View("SelectQuantity");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuantityConfirm(string Quantity)
        {
            Response.Cookies.Append("Quantity", Quantity);
            return View("ConfirmOrder");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmOrder()
        {
            return View();
        }

        public ActionResult SubmitOrder(LineItem newLineItem)
        {
            newLineItem.ProductID = Int32.Parse(Request.Cookies["ProductID"]);
            newLineItem.StoreID = Int32.Parse(Request.Cookies["StoreID"]);
            newLineItem.Quantity = Int32.Parse(Request.Cookies["Quantity"]);
            _bl.AddLineItem(newLineItem);
            _bl.UpdateStock(newLineItem.StoreID, newLineItem);
            return RedirectToAction("Profile", "Customer");
        }

        // GET: StoreController/Details/5
        public ActionResult ViewStoreInventory(string searching)
        {
            if (Request.Cookies["admin"] == "true")
            {
                if (!String.IsNullOrEmpty(searching))
                {
                    List<Inventory> inventory = _bl.GetInventory(Int32.Parse(searching));
                    return View("ViewInventory",inventory);
                }
                else
                {
                    List<Inventory> inventory = _bl.GetInventory(1);
                    return View("ViewInventory",inventory);
                }
            }
            else
            {
                return RedirectToAction("_NavAdmin");
            }
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
