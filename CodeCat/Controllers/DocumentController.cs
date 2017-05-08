using CodeCat.Models;
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

        [HttpPost]
        public ActionResult save(DocumentModel model)
        {
            //TODO: get the Document string and send to DB
            
            return RedirectToAction("../Project/ShowDocument");
        }

        public ActionResult addDocument(FormCollection collection)
        {
            //TODO
            //DocumentModel doc = new DocumentModel();
            return View();
        }
    }
}