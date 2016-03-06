using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MemberProfileController : Controller
    {
        // GET: MemberProfile
        public ActionResult Index()
        {

            //var db = new FabricsEntities();
            //var client = new Client() { ClientId=1};
            //db.Client.Add(client);
            //db.SaveChanges();
    

            return View();
        }

        
        public ActionResult MemberProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberProfile(MemberViewModel data)
        {
            return View();
        }
    
    }
}