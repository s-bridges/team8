using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using team8.Models;


namespace team8.Controllers
{
    public class LoginController : Controller
    {
        LoginDataLayer objLogin = new LoginDataLayer();

        //this is to get login info
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //check the login and return the customerID for use by payment and order controller
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string CustomerUserName, string CustomerPassword)
        {
            if (ModelState.IsValid)
            {

                Customer customer = objLogin.CustomerLogin(CustomerUserName, CustomerPassword);

                if (customer.CustomerID != 0)
                {
                    Session.CustomerID = customer.CustomerID;
                    return RedirectToAction("Index","Customer", new { customer.CustomerID });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}