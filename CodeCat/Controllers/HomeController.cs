using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.Models;

namespace CodeCat.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index(FormCollection collection)
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("../Dashboard/Dashboard");
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}