﻿using System;
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
            List<Catalog> lstCatalog = new List<Catalog>();
            lstCatalog = objCatalog.GetAllItems().ToList();


            return View(lstCatalog);
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