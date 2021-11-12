using MVC_Route.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Route.Controllers
{
    
    public class ProductController : Controller
    {
       private NorthwindEntities db = new NorthwindEntities();
        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        
        public ActionResult Details(string ProductName, int? ProductID)
        {

            return View(db.Products.Where(x=> x.ProductID == ProductID).FirstOrDefault());
        }

        public ActionResult Edit(string CategoryName, int CategoryID,string ProductName, int ProductID) 
        {
            if (ProductID==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(ProductID);
            if (product==null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName",product.SupplierID);
            return View(product);

        }

    }
}