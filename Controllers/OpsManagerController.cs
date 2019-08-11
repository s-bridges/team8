using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;


namespace team8.Controllers
{
    public class OpsManagerController : Controller
    {
        //create a variableto access each data layer. this acts as a sort of view model but it isnt.
        CustomerDataAccessLayer objCustomer = new CustomerDataAccessLayer();
        OrderDataLayer objOrder = new OrderDataLayer();
        EmployeeDataLayer objEmployee = new EmployeeDataLayer();
        PaymentDataLayer objPayment = new PaymentDataLayer();
        CatalogDataLayer objCatalog = new CatalogDataLayer();
        OpsManagerDataLayer objOps = new OpsManagerDataLayer();



        //controls for OPS MANAGER ---------------------------------------------------------------

        public IActionResult Index()
        {
            OpsManager ops = objOps.GetOpsManager(Convert.ToInt32(Session.OpsManagerID));

            return View(ops);
        }

        //get for all users
        public IActionResult AllUsers()
        {
            OpsManager ops = objOps.GetOpsManager(Convert.ToInt32(Session.OpsManagerID));

            return View(ops);
        }
        //this is for all users 
        [HttpPost]
        public IActionResult AllUsers(string userType)
        {
            if (ModelState.IsValid)
            {
                if (userType == null || userType == "C")
                {
                    return RedirectToAction("AllCustomer", "OpsManager");

                }
                if (userType == "E")
                {
                    return RedirectToAction("AllEmployee", "OpsManager");

                }
                if (userType == "O")
                {
                    return RedirectToAction("AllOps", "OpsManager");

                }

            }

            return RedirectToAction("Index");
        }



        //get ops details
        public IActionResult opsDetails(int? OpsManagerID)
        {
            if (OpsManagerID == null)
            {
                return NotFound();
            }

            OpsManager ops = objOps.GetOpsManager(OpsManagerID);

            if (ops == null)
            {
                return NotFound();
            }

            return View(ops);
        }

        //get all ops
        [HttpGet]
        public IActionResult AllOps()
        {

            List<OpsManager> lstOps = new List<OpsManager>();
            lstOps = objOps.GetAllOps().ToList();

            return View(lstOps);

        }


        //edit ops manager 
        [HttpGet]
        public IActionResult opsEdit(int? OpsManagerID)
        {
            if (OpsManagerID == null)
            {
                return NotFound();
            }

            OpsManager ops = objOps.GetOpsManager(OpsManagerID);

            if (ops == null)
            {
                return NotFound();
            }
            return View(ops);
        }
        //post the edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult opsEdit(int OpsManagerID, [Bind]OpsManager ops)
        {
            if (OpsManagerID != ops.OpsManagerID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objOps.UpdateOps(ops);
                return RedirectToAction("opsDetails", "OpsManager", new { ops.OpsManagerID });
            }
            return View(ops);
        }


        //add a new Ops Manager 
        [HttpGet]
        public IActionResult opsCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult opsCreate(OpsManager ops)
        {
            if (ModelState.IsValid)
            {
                objOps.AddOps(ops);
                return RedirectToAction("AllOps", "OpsManager");
            }
            return View(ops);
        }

        //FIX THIS ------ 
        //Delete an Ops manager
        [HttpGet]
        public IActionResult OpsDelete(int? OpsManagerID)
        {
            if (OpsManagerID == null)
            {
                return NotFound();
            }

            OpsManager ops = objOps.GetOpsManager(OpsManagerID);

            if (OpsManagerID == null)
            {
                return NotFound();
            }
            return View(ops);
        }
        //confirm delete
        [HttpPost, ActionName("OpsDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOpsConfirmed(int? OpsManagerID)
        {
            objCustomer.DeleteCustomer(OpsManagerID);
            return RedirectToAction("AllCustomers", "OpsManager");

        }


        //CUSTOMERS-------------------------------------------------------------------------------
        //View
        public IActionResult AllCustomer()
        {

            List<Customer> lstCustomer = new List<Customer>();
            lstCustomer = objCustomer.GetAllCustomers().ToList();

            return View(lstCustomer);

        }
        //details
        [HttpGet]
        public IActionResult cDetails(int? CustomerID)
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

        //delete
        [HttpGet]
        public IActionResult cDelete(int? CustomerID)
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
        [HttpPost, ActionName("cDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult  DeleteCustomerConfirmed(int? CustomerID)
        {
            objCustomer.DeleteCustomer(CustomerID);
            return RedirectToAction("AllCustomer", "OpsManager");

        }

        
        //EMPLOYEES--------------------------------------------------------------------------------
        //All EMployees 
        public IActionResult AllEmployee()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objEmployee.GetAllEmployees().ToList();

            return View(lstEmployee);
        }

        //details
        [HttpGet]
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


        //create employee account
        // 
        [HttpGet]
        public IActionResult EmployeeCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeCreate(Employee employee)
        {
            if (ModelState.IsValid)
            {
                objEmployee.AddEmployee(employee);
                return RedirectToAction("AllEmployee", "OpsManager");
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
                return RedirectToAction("EmployeeDetails", "OpsManager", new { employee.EmployeeID });
            }
            return View(employee);
        }

        //Delete

        //ORDERS ----------------------------------------------------------------------------------
        //view all
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

        [HttpGet]
        //orders by type ussed to show the status of each order
        public IActionResult orderByStatus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult orderByStatus(string orderType)
        {
            if (ModelState.IsValid)
            {
                if (orderType == null || orderType == "A")
                {
                    return RedirectToAction("AllOrders", "OpsManager");

                }

                else
                {
                    TempData["Status"] = orderType;
                    return RedirectToAction("orderStatus", "OpsManager");
                }

            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult orderStatus()
        {
            List<Order> lstOrder = new List<Order>();
            lstOrder = objOrder.OrderStatus(TempData["Status"].ToString()).ToList();

            if (lstOrder != null)
            {
                return View(lstOrder);
            }

            else
            {
                return View();
            }
        }


        //view one
        [HttpGet]
        public IActionResult orderDetails(int? OrderID)
        {
            if (OrderID == null)
            {
                return NotFound();
            }


            Order order = objOrder.GetOrderData(OrderID);
            TempData["OrderID"] = order.OrderID;

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        //all orders for a customer
        [HttpGet]
        public IActionResult cOrders(int CustomerID)
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

        //edit an order 
        [HttpGet]
        public IActionResult orderEdit(int? OrderID)
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
        [HttpPost]
        public IActionResult orderEdit(int OrderID, [Bind]Order order)
        {
            if (OrderID != order.OrderID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //get item price
                Catalog catalog = objCatalog.GetItemPrice(order.CatalogID);
                decimal itemPrice = Convert.ToDecimal(catalog.ItemPrice);

                //make variables to handle math
                int quantity = Convert.ToInt32(order.Quantity);
                decimal podPrice = Convert.ToDecimal(.10);

                //get the total 
                order.Total = Convert.ToDecimal(quantity * itemPrice);

                //total for payment on delivery
                if (order.PaymentType == "PODelivery")
                {
                   order.TotalDue = podPrice * order.Total;
                }
                else
                {
                    order.TotalDue = order.Total;
                }

                objOrder.UpdateOrder(order);
                return RedirectToAction("orderDetails", "OpsManager", new { order.OrderID });
            }
            return View(order);
        }

        //chagne the order status
        [HttpGet]
        public IActionResult orderChangeStatus(int? OrderID)
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
        [HttpPost]
        public IActionResult orderChangeStatus(int OrderID, [Bind]Order order)
        {
            if (OrderID != order.OrderID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //get item price
                Catalog catalog = objCatalog.GetItemPrice(order.CatalogID);
                decimal itemPrice = Convert.ToDecimal(catalog.ItemPrice);

                //make variables to handle math
                int quantity = Convert.ToInt32(order.Quantity);
                decimal podPrice = Convert.ToDecimal(.10);

                //get the total 
                order.Total = Convert.ToDecimal(quantity * itemPrice);

                //total for payment on delivery
                if (order.PaymentType == "PODelivery")
                {
                    order.TotalDue = podPrice * order.Total;
                }
                else
                {
                    order.TotalDue = order.Total;
                }

                objOrder.UpdateOrder(order);
                return RedirectToAction("orderDetails", "OpsManager", new { order.OrderID });
            }
            return View(order);
        }

        //CATALOG ---------------------------------------------------------------------------------
        //controls for catalog 
        //show the catalog
        public IActionResult Catalog()
        {
            List<Catalog> lstCatalog = new List<Catalog>();
            lstCatalog = objCatalog.GetAllItems().ToList();


            return View(lstCatalog);
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

        //PAYMENTS --------------------------------------------------------------------------------
        //payments for a customer
        [HttpGet]
        public IActionResult cPayments(int CustomerID)
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

        //get payment details for one card 
        [HttpGet]
        public IActionResult cPaymentDetails(int? CardID)
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


        //show payment info for order
        [HttpGet]
        public IActionResult orderPayment(int? CardID)
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

    }
}
