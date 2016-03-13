using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [紀錄Action的執行時間Attribute]
    public class HomeController : Controller
    {
        [共用ViewBag資料共享於部份HomeController動作方法]
        public ActionResult Index()
        {
            return View();
        }

        [共用ViewBag資料共享於部份HomeController動作方法]
        public ActionResult About()
        {
           // ViewBag.Message = "Your application description page.";
           
            return View();
        }

        public ActionResult Contact()
        {
            //測試elmah
            //throw new System.ApplicationException();

            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

    }
}