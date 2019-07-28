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
            if (CatalogID == null )
            {
                return NotFound();
            }
                       
            
            if (Session.CustomerID == 0)
            {
                TempData["URL"] = Request.Path.ToString();
                return RedirectToAction("Index", "Login");

            }

            Order order = new Order();
            order.CustomerID = Session.CustomerID;
            order.CatalogID = Convert.ToInt32(CatalogID);

            TempData["CustomerID"] = Session.CustomerID;

            
            return View(order);
        }
        [HttpPost]
        public IActionResult Create(int CatalogID,[Bind]Order order)
        {

            Catalog catalog = objCatalog.GetItemPrice(CatalogID);
            decimal itemPrice = Convert.ToDecimal(catalog.ItemPrice);
            int quantity = Convert.ToInt32(order.Quantity);

            if (ModelState.IsValid)
            {
                //if (order.PaymentType == "PODelivery")
                //{
                //   logic for the 10% down on podelivery on credit card
                //}

                order.Total = Convert.ToDecimal(quantity * itemPrice);

                objOrder.AddOrder(order);
                return RedirectToAction("Index", "Customer", new { order.CustomerID });
            }
            return View(order);
        }
    }
}