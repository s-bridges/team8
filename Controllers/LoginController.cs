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
        public IActionResult Index(string UserName, string Password, string UserType)
        {
            if (ModelState.IsValid)
            {
                if (UserType == null || UserType == "Customer")
                {
                    Customer customer = objLogin.CustomerLogin(UserName, Password);

                    if (customer.CustomerID != 0)
                    {
                        Session.CustomerID = customer.CustomerID;
                        return RedirectToAction("Index", "Customer", new { customer.CustomerID });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                if (UserType == "Employee")
                {
                    Employee employee = objLogin.EmployeeLogin(UserName, Password);
                    
                    if (employee.EmployeeID != 0)
                    {
                        Session.EmployeeID = employee.EmployeeID;
                        return RedirectToAction("Index", "Employee", new { employee.EmployeeID });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                if (UserType == "OpsManager")
                {
                    OpsManager opsManager = objLogin.OpsManagerLogin(UserName, Password);

                    if (opsManager.OpsManagerID != 0)
                    {
                        Session.EmployeeID = opsManager.OpsManagerID;
                        return RedirectToAction("Index", "OpsManager", new { opsManager.OpsManagerID });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

            }

            return RedirectToAction("Index");
        }
    }
}