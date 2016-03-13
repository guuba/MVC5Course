using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class 共用ViewBag資料共享於部份HomeController動作方法Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.";

            //也可在執行Action即透過條件判斷予以導向
            //if (!filterContext.HttpContext.Request.IsLocal)
            //{
            //    filterContext.Result = new RedirectResult("/");
            //}

            base.OnActionExecuting(filterContext);
        }
    }
}


