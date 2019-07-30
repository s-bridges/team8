using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using team8.Models;

namespace team8.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            if (Session.CustomerID == 0)
            {
                if (Session.OpsManagerID == 0)
                {
                    if (Session.EmployeeID == 0)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                }
            }

            if (Session.CustomerID != 0)
            {
                return RedirectToAction("Index", "Customer");
            }

            if (Session.OpsManagerID != 0)
            {
                return RedirectToAction("Index", "OpsManager");
            }

            if (Session.EmployeeID != 0)
            {
                return RedirectToAction("Index", "Employee");
            }

            return View();
        }
    }
}