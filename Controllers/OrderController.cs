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



        //shows all orders for a customer
        [HttpGet]
        public IActionResult Index(int CustomerID)
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

            return View(order);
        }

        [HttpGet]
        public IActionResult Create(int? CatalogID)
        {
            if (Session.CustomerID == 0)
            {
                return RedirectToAction("CustomerLogin");
            }
            

            return View();
        }
    }
}