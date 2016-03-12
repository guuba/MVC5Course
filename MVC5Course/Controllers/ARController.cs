using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            //PartialView不會套用_layout
            return PartialView("Index");
        }

        public ActionResult ContentTest()
        {
            //不建議這麼寫，更改需重新complier才可執行
            return Content("<script>alert('Redriecting ...');</script>",
                "application/javascript", Encoding.UTF8);
        }

        public ActionResult FileTest()
        {
            //ContentType對應名稱請參考 :http://tool.oschina.net/commons
            
            //直接在網頁上開啟
            return File(
               Server.MapPath("~/Content/alphago-logo.png"),
               "image/png");
            
            ////加入第三個下載命名屬性，會直接下載並名命完成
            //return File(
            //    Server.MapPath("~/Content/alphago-logo.png"),
            //    "image/png",
            //    "GoGoGo.png");
        }
    }
}