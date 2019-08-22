using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using team8.Models;


namespace team8.Controllers
{
    public class CatalogController : Controller
    {
        CatalogDataLayer objCatalog = new CatalogDataLayer();


        public IActionResult Index()
        {
            Catalog catalog = new Catalog();
            catalog._lstCatalog = objCatalog.GetAllItems().ToList();

            return View(catalog);
        }
        [HttpPost]
        public IActionResult Index(string ItemName)
        {
            Catalog catalog = new Catalog();
            char firstLetter;

            firstLetter = ItemName[0];


            ///truncate and then Search
            catalog._lstCatalog = objCatalog.GetCatalogName(firstLetter);

            return View(catalog);
        }


        [HttpGet]
        public IActionResult Details(int? CatalogID)
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
    }
}