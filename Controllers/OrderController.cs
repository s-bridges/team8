using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;



namespace team8.Controllers
{
    public class OrderController : Controller
    {
        OrderDataLayer objOrder = new OrderDataLayer();
        CatalogDataLayer objCatalog = new CatalogDataLayer();
        PaymentDataLayer objPayment = new PaymentDataLayer();
        CustomerDataAccessLayer objCustomer = new CustomerDataAccessLayer();

        //all orders for a customer
        [HttpGet]
        public IActionResult Index(int CustomerID)
        {
            Order order = new Order();
            order._lstOrders = objOrder.GetAllCustomerOrder(Convert.ToInt32(CustomerID));

            if (order._lstOrders != null)
            {
                TempData["CustomerID"] = CustomerID;

                return View(order);
            }

            else
            {
                return View();
            }

        }
        [HttpPost]
        public IActionResult Index(int CustomerID, string orderType)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order();

                if (orderType == "A")
                {
                    order._lstOrders = objOrder.GetAllCustomerOrder(Convert.ToInt32(CustomerID));
                    return View(order);
                }
                else
                {
                    order._lstOrders = objOrder.CustomerOrderStatus(CustomerID, orderType);
                    return View(order);
                }
            }

            return View();
        }


        //show details for one order
        [HttpGet]
        public IActionResult Details(int? OrderID)
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

            int CardID = order.CardID;
            order.payment = objPayment.GetPaymentData(CardID);

            int CatalogID = order.CatalogID;
            order.catalog = objCatalog.GetOrderCatalog(CatalogID);

            int CustomerID = order.CustomerID;
            order.customer = objCustomer.GetCustomerData(CustomerID);



            return View(order);
        }
                          
    }
}