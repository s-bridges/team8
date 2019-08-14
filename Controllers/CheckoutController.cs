using System;
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
            Checkout checkout = new Checkout
            {
                order = new Order(),
                catalog = new Catalog(),
            };

            //fill the form with the required ORDER items
            checkout.order.CustomerID = Session.CustomerID;
            checkout.order.CatalogID = Convert.ToInt32(CatalogID);

            //get the CATALOG items
            //item price
            checkout.catalog = objCatalog.GetOrderCatalog(CatalogID);
            TempData["CatalogID"] = checkout.catalog.CatalogID;
            //get the payment information for display

            




            return View(checkout);
        }

        //this will transfer info to payment page.
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



            Session.Checkout.catalog = checkout.catalog;
            Session.Checkout.order = checkout.order;

           // objOrder.AddOrder(checkout);
            
            return RedirectToAction("cPayment", "Checkout" );
        }


        //send info to payment screen
        public IActionResult cPayment()
        {
            //new view model
            Checkout checkout = new Checkout
            {
                order = Session.Checkout.order,
                catalog = Session.Checkout.catalog,                
            };


            //stuff to display either a list of stored cards or to add a new card to the order. 
            Payment payment = new Payment();
            checkout.payment = payment;
            checkout.payment.lstPayment = objPayment.GetAllCustomerPayment(Convert.ToInt32(Session.CustomerID)).ToList();
            checkout.payment.CustomerID = Session.CustomerID;



            return View(checkout);

        }

        //get payment model for finalization
        [HttpPost]
        public IActionResult cPayment([Bind]Checkout checkout)
        {
            Session.Checkout.order.CardID = Convert.ToInt32(checkout.order.CardID);
            Session.Checkout.payment = objPayment.GetPaymentData(Convert.ToInt32(checkout.order.CardID));
            return RedirectToAction("cFinalize", "Checkout");
        }

        [HttpPost]
        public IActionResult cPaymentCreate([Bind]Checkout checkout)
        {
            if (ModelState.IsValid)
            {
                
                objPayment.AddPayment(checkout.payment);

                checkout.payment = objPayment.FindCard(Convert.ToInt32(checkout.payment.CardNumber));
                Session.Checkout.payment = checkout.payment;
                Session.Checkout.order.CardID = Convert.ToInt32(checkout.payment.CardID);

                return RedirectToAction("cFinalize", "Checkout");

            }
            return View(checkout);
        }




        // controls for finalization.
        public IActionResult cFinalize()
        {
            //Initialize 
            Checkout checkout = new Checkout
            {
                order = Session.Checkout.order,
                payment = Session.Checkout.payment,
                
            };

            Catalog catalog = new Catalog();
            checkout.catalog = catalog;
            checkout.catalog = objCatalog.GetOrderCatalog(Convert.ToInt32(Session.Checkout.order.CatalogID));
            Session.Checkout.catalog = checkout.catalog;

            return View(checkout);
        }

        [HttpPost]
        public IActionResult cFinalize([Bind]Checkout checkout)
        {
            checkout.order = Session.Checkout.order;
            objOrder.AddOrder(checkout);
            return RedirectToAction("cReceipt", "Checkout");
        }

        public IActionResult cReceipt()
        {
            Checkout checkout = new Checkout
            {
                order = Session.Checkout.order,
                payment = Session.Checkout.payment,
                catalog = Session.Checkout.catalog
            };



            return View(checkout);
        }
    }
}