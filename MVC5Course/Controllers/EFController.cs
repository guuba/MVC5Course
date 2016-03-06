using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        private Product prod;

        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities();

            var product = new Product()
            {
                ProductName = "March",
                Price = 58,
                Stock = 1,
                Active = true
            };

            db.Product.Add(product);


            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    string entityName = item.Entry.Entity.GetType().Name;

                    foreach (DbValidationError err in item.ValidationErrors)
                    {
                        throw new Exception(entityName + " 類型驗證失敗: " + err.ErrorMessage);
                    }
                }
                throw;
            }
            
            var pkey = product.ProductId;
            //var data = db.Product.ToList();
            //var data = db.Product.Where(p => p.ProductId == pkey).ToList();
            //var data = db.Product.FirstOrDefault(p => p.ProductId == pkey);
            //var data = db.Product.OrderByDescending(p => p.ProductId);
            //var data = db.Product.Find(pkey);<--- VIEW為IQueryable 此為單筆資料所以會生錯誤
            //var data = db.Product.Where(p => p.ProductId == pkey).ToList();

            //var data = db.Product.Where(p => p.ProductId == pkey).ToList();

            var data = db.Product.OrderByDescending(p => p.ProductId).Take(5);

            foreach (var item in data)
            {
                item.Price = item.Price + 1;
            }

            db.SaveChanges();

            return View(data);
        }

        public ActionResult Detail(int id)
        {
            //var data = db.Product.Find(id);
            //var data = db.Product.Where(p => p.ProductId == id).FirstOrDefault();
            var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            return View(data);

        }

        public ActionResult Delete(int id)
        {
            var item = db.Product.Find(id);
            db.Product.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}