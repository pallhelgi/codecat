using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeCat.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult save()
        {
            //TODO
            return View();
        }

        public ActionResult addDocument(FormCollection collection)
        {
            //TODO
            return View();
        }
    }
}