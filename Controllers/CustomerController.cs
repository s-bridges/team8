using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;

namespace team8.Controllers
{
    public class CustomerController : Controller
    {
        //index page
        CustomerDataAccessLayer objCustomer = new CustomerDataAccessLayer();
        

        public IActionResult Index()
        {
            List<Customer> lstCustomer = new List<Customer>();
            lstCustomer = objCustomer.GetAllCustomers().ToList();


            return View(lstCustomer);
        }
        

        //create customer

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //create customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                objCustomer.AddCustomer(customer);
                return RedirectToAction("Index");

            }
            return View(customer);
        }

        //edit customer
        [HttpGet]
        public IActionResult Edit(int? CustomerID)
        {
            if (CustomerID == null)
            { return NotFound(); }

            Customer customer = objCustomer.GetCustomerData(CustomerID);

            if (customer == null)
            { return NotFound(); }
            return View(customer);           
        }

        //edit customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int CustomerID, [Bind]Customer customer)
        {
            if (CustomerID != customer.CustomerID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objCustomer.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //details on single customer
        [HttpGet]
        public IActionResult Details(int? CustomerID)
        {
            if(CustomerID == null)
            {
                return NotFound();
            }

            Customer customer = objCustomer.GetCustomerData(CustomerID);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }


        //delete customer 
        [HttpGet]
        public IActionResult Delete(int? CustomerID)
        {
            if (CustomerID == null)
            {
                return NotFound();
            }

            Customer customer = objCustomer.GetCustomerData(CustomerID);

            if (CustomerID == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        //confirm delete

        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? CustomerID)
        {
           // objCustomer.DeleteCustomer(CustomerID);
            return RedirectToAction("Index");

        }
    }
}