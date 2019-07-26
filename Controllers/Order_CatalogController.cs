using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;

namespace team8.Controllers
{
    public class Order_CatalogController : Controller
    {
        Order_CatalogDataLayer objCatalog = new Order_CatalogDataLayer();

        [HttpGet]
        public IActionResult Index(int CatalogID)
        {
            if (CatalogID == 0)
            {
                return NotFound();
            }
            if (TempData["cart"] == null)
            {
                Order_Catalog orderCat = new Order_Catalog();
                orderCat.CatalogID = CatalogID;

                TempData["cart"] = orderCat;
                

            }
                       
            
            return View();
        }
        


    }
}