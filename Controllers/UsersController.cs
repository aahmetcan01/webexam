using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity2;


namespace MVCStok.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        MVCDbStokEntities2 db = new MVCDbStokEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Userss log)
        {
            var user = db.Userss.Where(x => x.Username == log.Username && x.password == log.password).Count();

            if (user > 0)
            {
                return RedirectToAction("DashBoard");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult DashBoard()
        {
            return View();
        }
    }
}