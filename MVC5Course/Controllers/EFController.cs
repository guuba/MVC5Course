using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities();

            db.Product.Add(new Product()
            {
                ProductName = "BMW",
                Price = 20,
                Stock = 1,
                Active = true
            });
            
            db.SaveChanges();
            var data = db.Product.ToList();

            return View(data);
        }
    }
}