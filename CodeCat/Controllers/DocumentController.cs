using CodeCat.Models;
using CodeCat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeCat.Controllers
{
    public class DocumentController : Controller
    {
        DocumentService docService = new DocumentService();
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

        [HttpGet]
        public ActionResult addDocument(FormCollection collection)
        {
            //TODO
            //DocumentModel doc = new DocumentModel();
            return View();
        }

        [HttpPost]
        public ActionResult addDocument(DocumentModel docFromUser)
        {
            if(ModelState.IsValid)
            {
                DocumentModel doc = new DocumentModel();
                doc = docFromUser;
                //This is hardcoded, should not be so yo
                doc.name = docFromUser.name + ".js";
                //Maybe add some default code in content
                doc.content = null;
                doc.projectID = 3;
                docService.addDocument(doc);

                return RedirectToAction("PROJECT SIDAN");
            }

            return View(docFromUser);
        }
     }
}