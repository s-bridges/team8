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
             
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userType)
        {
            if (ModelState.IsValid)
            {
                if (userType == null || userType == "C")
                {
                    return RedirectToAction("AllCustomers");

                }
                if (userType == "E")
                {
                    return RedirectToAction("AllEmployees");

                }
                if (userType == "O")
                {
                    return RedirectToAction("AllOps");

                }

            }

            return RedirectToAction("Index");
        }

        //show the customers
        [HttpGet]
        public IActionResult AllCustomers()
        {

            List<Customer> lstCustomer = new List<Customer>();
            lstCustomer = objCustomer.GetAllCustomers().ToList();

            return View(lstCustomer);

        }

        //show all employees
        [HttpGet]
        public IActionResult AllEmployees()
        {

            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objEmployee.GetAllEmployees().ToList();

            return View(lstEmployee);

        }
        [HttpGet]
        public IActionResult AllOps()
        {

            List<OpsManager> lstOps= new List<OpsManager>();
            lstOps = objOps.GetAllOps().ToList();

            return View(lstOps);

        }
    }
}