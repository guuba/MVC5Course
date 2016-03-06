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

        public ActionResult Index(bool? IsActive,string Keyword)
        {
            var product = new Product()
            {
                ProductName = "BMW",
                Price = 2,
                Stock = 1,
                Active = true
            };

            //db.Product.Add(product);
            //SaveChanges();

            var pkey = product.ProductId;

            //var data = db.Product.Where(p => p.ProductId == pkey).ToList();

            var data = db.Product.OrderByDescending(p => p.ProductId).AsQueryable();

            if (IsActive.HasValue)
            {
                data = data.Where(p => p.Active.HasValue ? p.Active.Value == IsActive.Value : false);
            }
            if(!string.IsNullOrWhiteSpace(Keyword))
            {
                data = data.Where(p => p.ProductName.Contains(Keyword));
            }
            
            foreach (var item in data)
            {
                item.Price = item.Price + 1;
            }

            SaveChanges();

            return View(data);
        }

        private void SaveChanges()
        {
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
            var product = db.Product.Find(id);

            //foreach (var ol in db.OrderLine.Where(p => p.ProductId == id).ToList())
            //{
            //    db.OrderLine.Remove(ol);
            //}

            //foreach (var ol in product.OrderLine.ToList())
            //{
            //    db.OrderLine.Remove(ol);
            //}

            db.OrderLine.RemoveRange(product.OrderLine);

            db.Product.Remove(product);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}