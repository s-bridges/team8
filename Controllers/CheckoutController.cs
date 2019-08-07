﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;

namespace team8.Controllers
{


    public class CheckoutController : Controller
    {
        OrderDataLayer objOrder = new OrderDataLayer();
        CatalogDataLayer objCatalog = new CatalogDataLayer();
        PaymentDataLayer objPayment = new PaymentDataLayer();


        //this is the chekout object that ccontains the models for 
        //all of the other models in order to combine the photos, prices, 
        //payment types of a user ect..ect..
        [HttpGet]
        public IActionResult Index(int? CatalogID)
        {
            if (CatalogID == null)
            {
                return NotFound();
            }
            if (Session.CustomerID == 0)
            {
                TempData["URL"] = Request.Path.ToString();
                return RedirectToAction("Index", "Login");

            }

            //new view model
            Checkout checkout = new Checkout();
            checkout.order = new Order();
            checkout.catalog = new Catalog();
            checkout.payment = new Payment();

            //fill the form with the required ORDER items
            checkout.order.CustomerID = Session.CustomerID;
            checkout.order.CatalogID = Convert.ToInt32(CatalogID);

            //get the CATALOG items
            //item price
            checkout.catalog = objCatalog.GetOrderCatalog(CatalogID);
            TempData["CatalogID"] = checkout.catalog.CatalogID;
            //get the payment information for display

            checkout.payment.lstPayment = objPayment.GetAllCustomerPayment(Convert.ToInt32(Session.CustomerID)).ToList();
            

            if (checkout.payment.lstPayment == null)
            {
                return RedirectToAction("Create", "Payment", Session.CustomerID);
            }


            return View(checkout);
        }

        //this will post the new order to the data base
        [HttpPost]
        public IActionResult Index([Bind]Checkout checkout)
        {
           
            //works
            Catalog catalog = objCatalog.GetItemPrice(Convert.ToInt32(TempData["CatalogID"]));
            decimal itemPrice = Convert.ToDecimal(catalog.ItemPrice);

            //works
            int quantity = Convert.ToInt32(checkout.order.Quantity);
            decimal podPrice = Convert.ToDecimal(.10);



            //get the total 
            checkout.order.Total = Convert.ToDecimal(quantity * itemPrice);

            //total for payment on delivery
            if (checkout.order.PaymentType == "PODelivery")
            {
                checkout.order.TotalDue = podPrice * checkout.order.Total;
            }
            else
            {
                checkout.order.TotalDue = checkout.order.Total;
            }

                objOrder.AddOrder(checkout);
            
                return RedirectToAction("Index", "Order", new { Session.CustomerID });
        }
       
    }
}