using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }

        //模型繋結方法
        [HttpPost]
        public ActionResult Index(string Name, DateTime Birthday)
        {
            return Content(Name + "" + Birthday);
        }


        //FormCollection方法，注意此處的Birthday的值單純就只用文字格式呈現
        //[HttpPost]
        //public ActionResult Index(FormCollection form)
        //{
        //    return Content(form["Name"] + "" + form["Birthday"]);
        //}

        //強型別模型繋結方法
        //[HttpPost]
        //public ActionResult Index(MemberViewModel t)
        //{
        //    return Content(t.Name + "" + t.Birthday);
        //}
    }
}