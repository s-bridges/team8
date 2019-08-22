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
        OpsManagerDataLayer objOps = new OpsManagerDataLayer();


        public IActionResult Index()
        {
            AllUsers users = new AllUsers
            {
                _lstCustomers = objCustomer.GetAllCustomers().ToList(),
                _lstEmployees = objEmployee.GetAllEmployees().ToList(),
                _lstOps = objOps.GetAllOps().ToList()
            };

            return View(users);
        }

        [HttpPost]
        public IActionResult Index(string userType)
        {
            if (ModelState.IsValid)
            {
                AllUsers users = new AllUsers();
                if (userType == "A")
                {

                    users._lstCustomers = objCustomer.GetAllCustomers().ToList();
                    users._lstEmployees = objEmployee.GetAllEmployees().ToList();
                    users._lstOps = objOps.GetAllOps().ToList();
                   

                    return View(users);
                }
                if (userType == "C")
                {

                    users._lstCustomers = objCustomer.GetAllCustomers().ToList();
                    users._lstEmployees = null;
                    users._lstOps = null;


                    return View(users);
                }
                if (userType == "E")
                {
                    users._lstEmployees = objEmployee.GetAllEmployees().ToList();
                    users._lstCustomers = null;
                    users._lstOps = null;

                    return View(users);

                }
                if (userType == "O")
                {
                    users._lstOps = objOps.GetAllOps().ToList();
                    users._lstCustomers = null;
                    users._lstEmployees = null;

                    return View(users);
                }

            }

            return RedirectToAction("Index");
        }

    }
}