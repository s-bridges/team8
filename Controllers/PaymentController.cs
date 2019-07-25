using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;


namespace team8.Controllers
{
    public class PaymentController : Controller
    {
        PaymentDataLayer objPayment = new PaymentDataLayer();


        //index page controller
        [HttpGet ]
        public IActionResult Index(int CustomerID)
        {


            List<Payment> lstPayment = new List<Payment>();
            lstPayment = objPayment.GetAllCustomerPayment(CustomerID).ToList();


            return View(lstPayment);
        }

                            
        //create payment option form
        [HttpGet]
        public IActionResult Create(int? CustomerID)
        {

            if (CustomerID == null)
            { return NotFound(); }

            return View();
            
        }

        //post the form to the DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int CustomerID, [Bind]Payment payment)
        {
            if (ModelState.IsValid)
            {
                

                objPayment.AddPayment(payment);

                return RedirectToAction("Index", new {payment.CustomerID});

            }
            return View(payment);
        }

        //edit Card
        [HttpGet]
        public IActionResult Edit(int? CardID)
        {
            if (CardID == null)
            { return NotFound(); }

            Payment payment = objPayment.GetPaymentData(CardID);

            
            if (payment == null)
            { return NotFound(); }
            return View(payment);
        }

        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? CardID, int CustomerID, [Bind]Payment payment)
        {
            if (CardID != payment.CardID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objPayment.UpdatePayment(payment);
                return RedirectToAction("Index", new { payment.CustomerID });
            }
            return View(payment);
        }
        
        //find one customer payment option
        [HttpGet]
        public IActionResult Details(int? CardID)
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

        //delete a card
        [HttpGet]
        public IActionResult Delete(int? CardID)
        {
            if (CardID == null)
            {
                return NotFound();
            }

            Payment payment = objPayment.GetPaymentData(CardID);

            if (CardID == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        //confirm delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? CardID)
        {
            objPayment.DeletePayment(CardID);
            return RedirectToAction("Index");

        }


    }
}
