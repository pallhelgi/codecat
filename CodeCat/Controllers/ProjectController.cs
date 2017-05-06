using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeCat.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            //TODO
           
            return View();
        }

        public ActionResult addDocument(FormCollection collection)
        {
            //TODO
            return View();
        }

        public ActionResult save()
        {
            //TODO
            return View();
        }

        public ActionResult share(UserModel user)
        {
            //TODO
            return View();
        }

        public ActionResult showDocument()
        {
            //TODO
            return View();
        }
    }
}