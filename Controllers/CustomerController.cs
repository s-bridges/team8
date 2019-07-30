using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using team8.Models;


namespace team8.Controllers
{
    public class CustomerController : Controller
    {
        //index page
        CustomerDataAccessLayer objCustomer = new CustomerDataAccessLayer();
        [HttpGet]
        public IActionResult Index(int? CustomerID)
        {
            if (Session.CustomerID == 0)
            {
                return RedirectToAction("Index", "Login");
            }

            CustomerID = Session.CustomerID;
            Customer customer = objCustomer.GetCustomerData(CustomerID);
            if (customer != null)
            {
            }
            
            return View(customer);

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
                Session.CustomerID = customer.CustomerID;
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
                return RedirectToAction("Index", new {customer.CustomerID });
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
        


        [HttpGet]
        public IActionResult ViewAllCustomers()
        {

            {
                List<Customer> lstCustomer = new List<Customer>();
                lstCustomer = objCustomer.GetAllCustomers().ToList();


                return View(lstCustomer);
            }
        }
    }
}