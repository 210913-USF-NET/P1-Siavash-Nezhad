using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private IBL _bl;
        public CustomerController(IBL bl)
        {
            _bl = bl;
        }
        // GET: LoginController
        public ActionResult SearchCustomers()
        {
            return View("Index");
        }
        public ActionResult Index(string searching)
        {
            if (Request.Cookies["userId"] != null)
            {
                if (Request.Cookies["admin"] == "true")
                {
                    if (!String.IsNullOrEmpty(searching))
                    {
                        List<Customer> customer = _bl.GetCustomer(searching);
                        return View(customer);
                    }
                    else
                    {
                        List<Customer> allCustomers = _bl.GetAllCustomers();
                        return View(allCustomers);
                    }
                }
                else
                {
                    return RedirectToAction("Profile", Convert.ToInt32(Request.Cookies["userId"]));
                }
            }
            else
            {
                return RedirectToAction("_GuestIndex", "Home");
            }
        }
        public ActionResult Profile(int id)
        {
            if (Request.Cookies["userId"] != null)
            {
                Customer currentUser = _bl.GetCustomer(Request.Cookies["userName"])[0];
                return RedirectToAction("_UserIndex","Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddCustomer(user);
                    return RedirectToAction(nameof(Index));
                }
                //needs error message
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            if (Request.Cookies["userId"] != null)
            {
                return RedirectToAction("Login", new { email = "userEmail" });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(string email)
        {
            try
            {
                bool success = false;
                List<Customer> allCustomer = _bl.GetAllCustomers();
                foreach (Customer customer in allCustomer)
                {
                    if (customer.Email == email)
                    {
                        HttpContext.Response.Cookies.Append("userEmail", email);
                        HttpContext.Response.Cookies.Append("userId", customer.CustomerID.ToString());
                        HttpContext.Response.Cookies.Append("user", "true");
                        HttpContext.Response.Cookies.Append("admin", "false");
                        HttpContext.Response.Cookies.Append("userName", customer.Name);
                        success = true;
                        return RedirectToAction("_UserIndex", "Home");
                    }
                }

                if (email == "shrek")
                {
                    HttpContext.Response.Cookies.Append("user", "false");
                    HttpContext.Response.Cookies.Append("admin", "true");
                    success = true;
                    return RedirectToAction("_AdminIndex", "Home");
                }

                if (!success)
                {
                    return Content("Input does not match our records. Please try again.");
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["userId"] != null)
            {
                Response.Cookies.Delete("userId");
                Response.Cookies.Delete("userName");
                Response.Cookies.Delete("admin");
            }
            return RedirectToAction("Login");
        }
        // GET: LoginController/Edit/5
        public ActionResult Edit(string name)
        {
            ViewBag.UserToEdit = name;
            if (Request.Cookies["userId"] != null)
            {
                Customer currentUser = _bl.GetCustomer(Request.Cookies["userName"])[0];
                if (Request.Cookies["admin"] == "true" == true)
                {
                    Customer targetUser = _bl.GetCustomer(name)[0];

                    return View(targetUser);
                }
                else
                {
                    return View(currentUser);
                }
            }
            else return RedirectToAction("Login");
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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