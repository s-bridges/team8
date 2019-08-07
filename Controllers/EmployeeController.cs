using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;

namespace team8.Controllers
{
    public class EmployeeController : Controller
    {

        CustomerDataAccessLayer objCustomer = new CustomerDataAccessLayer();
        OrderDataLayer objOrder = new OrderDataLayer();
        EmployeeDataLayer objEmployee = new EmployeeDataLayer();
        PaymentDataLayer objPayment = new PaymentDataLayer();
        CatalogDataLayer objCatalog = new CatalogDataLayer();

        public IActionResult Index()
        {
            Employee employee = objEmployee.GetEmployeeData(Convert.ToInt32(Session.EmployeeID));
                        
            return View(employee);
        }

        //controls for employee
        //get employee details
        public IActionResult EmployeeDetails(int? EmployeeID)
        {
            if (EmployeeID == null)
            {
                return NotFound();
            }

            Employee employee = objEmployee.GetEmployeeData(EmployeeID);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        //edit employee
        [HttpGet]
        public IActionResult EmployeeEdit(int? EmployeeID)
        {
            if (EmployeeID == null)
            { return NotFound(); }

            Employee employee = objEmployee.GetEmployeeData(EmployeeID);

            if (employee == null)
            { return NotFound(); }
            return View(employee);
        }

        //edit employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmployeeEdit(int EmployeeID, [Bind]Employee employee)
        {
            if (EmployeeID != employee.EmployeeID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objEmployee.UpdateEmployee(employee);
                return RedirectToAction("Index","Employee", new { employee.EmployeeID });
            }
            return View(employee);
        }

        //-----------------------------------------------------
        //all controls for customer

        //get all customers
        [HttpGet]
        public IActionResult AllCustomers()
        {
                        
                List<Customer> lstCustomer = new List<Customer>();
                lstCustomer = objCustomer.GetAllCustomers().ToList();

                return View(lstCustomer);
            
        }
        //details on single customer
        [HttpGet]
        public IActionResult CustomerDetails(int? CustomerID)
        {
            if (CustomerID == null)
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


        //delete a customer
        //delete customer 
        [HttpGet]
        public IActionResult CustomerDelete(int? CustomerID)
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

        [HttpPost, ActionName("CustomerDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? CustomerID)
        {
            objCustomer.DeleteCustomer(CustomerID);
            return RedirectToAction("AllCustomers", "Employee");

        }



        //------------------------------------------------------

        //controls for orders
        //get all orders        
        [HttpGet]
        public IActionResult AllOrders()
        {
            List<Order> lstOrder = new List<Order>();
            lstOrder = objOrder.GetAllOrder().ToList();

            if (lstOrder != null)
            {
                return View(lstOrder);
            }

            else
            {
                return View();
            }

        }

        //details for a single order
        [HttpGet]
        public IActionResult OrderDetails(int? OrderID)
        {
            if (OrderID == null)
            {
                return NotFound();
            }


            Order order = objOrder.GetOrderData(OrderID);


            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        //get all orders for a customer
        [HttpGet]
        public IActionResult CustomerOrders(int CustomerID)
        {
            List<Order> lstOrder = new List<Order>();
            lstOrder = objOrder.GetAllCustomerOrder(CustomerID).ToList();

            if (lstOrder != null)
            {
                TempData["CustomerID"] = CustomerID;

                return View(lstOrder);
            }

            else
            {
                return View();
            }

        }

        //---------------------------------------------------

        //controls for payment
        //index page controller
        [HttpGet]
        public IActionResult CustomerPayment(int CustomerID)
        {


            List<Payment> lstPayment = new List<Payment>();
            lstPayment = objPayment.GetAllCustomerPayment(CustomerID).ToList();

            if (lstPayment != null)
            {
                TempData["CustomerID"] = CustomerID;
                return View(lstPayment);
            }
            else
            {
                return View();
            }

        }

        //get payment details for a customer
        [HttpGet]
        public IActionResult CustomerPaymentDetails(int? CardID)
        {
            if (CardID == null)
            {
                return NotFound();
            }
            Payment payment = objPayment.GetPaymentData(CardID);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }


        //------------------------------------------------------------


        //controls for catalog 
        //edit catalog
        [HttpGet]
        public IActionResult CatalogEdit(int? CatalogID)
        {
            if (CatalogID == null)
            { return NotFound(); }

            Catalog catalog = objCatalog.GetOrderCatalog(CatalogID);

            if (catalog == null)
            { return NotFound(); }
            return View(catalog);
        }

        //edit catalog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CatalogEdit(int CatalogID, [Bind]Catalog catalog)
        {
            if (CatalogID != catalog.CatalogID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objCatalog.UpdateCatalog(catalog);
                return RedirectToAction("Catalog");
            }
            return View(catalog);
        }

        //show the catalog
        public IActionResult Catalog()
        {
            List<Catalog> lstCatalog = new List<Catalog>();
            lstCatalog = objCatalog.GetAllItems().ToList();


            return View(lstCatalog);
        }

        //create new catalog entry
        public IActionResult CatalogCreate()
        {
            return View();
        }
        //post the new item
        [HttpPost]
        public IActionResult CatalogCreate(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                objCatalog.AddCatalog(catalog);
                return RedirectToAction("Catalog");
            }
            return View(catalog);
        }

        //catalog details
        [HttpGet]
        public IActionResult CatalogDetails(int? CatalogID)
        {
            if (CatalogID == null)
            {
                return NotFound();
            }

            Catalog catalog = objCatalog.GetOrderCatalog(CatalogID);

            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        //delete catalog
        [HttpGet]
        public IActionResult CatalogDelete(int? CatalogID)
        {
            if (CatalogID == null)
            {
                return NotFound();
            }

            Catalog catalog = objCatalog.GetOrderCatalog(CatalogID);

            if (CatalogID == null)
            {
                return NotFound();
            }
            return View(catalog);
        }
        //confirm delete

        [HttpPost, ActionName("CatalogDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCatalogConfirmed(int? CatalogID)
        {
            objCatalog.DeleteCatalog(CatalogID);
            return RedirectToAction("Catalog", "Employee");

        }
    }
}