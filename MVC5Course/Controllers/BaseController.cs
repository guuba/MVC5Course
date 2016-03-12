using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
        //若找不到Action則導回首頁
        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/").ExecuteResult(this.ControllerContext);
        }

       protected ProductRepository repo = RepositoryHelper.GetProductRepository();

        public ActionResult Debug()
        {
            return Content("DEBUG");
        }
    }
}