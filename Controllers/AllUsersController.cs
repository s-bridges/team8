using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;

namespace team8.Controllers
{
    public class AllUsersController : Controller
    {
        CustomerDataAccessLayer objCustomer = new CustomerDataAccessLayer();
        EmployeeDataLayer objEmployee = new EmployeeDataLayer();

        public IActionResult Index()
        {
             
            return View();
        }
    }
}