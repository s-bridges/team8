using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;

namespace team8.Controllers
{
    public class Logout : Controller
    {

        public IActionResult Index()
        {
            Session.CustomerID = 0;
            Session.EmployeeID = 0;
            Session.OpsManagerID = 0;

            return RedirectToAction("Index", "Home");
        }
    }
}
