using CodeCat.Models;
using CodeCat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.Models.ViewModels;

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

       /* [HttpPost]
        public ActionResult save(DocumentViewModel model)
        {
            //TODO: get the Document string and send to DB
            int docID = model.document.ID;
            var output = model.document.content;
            docService.saveDocument(docID, output);
            ViewBag.Code = output;

            return RedirectToAction("../Project/ShowDocument");
        }*/


        // [AjaxAuthorize]
        [HttpPost]
        public ActionResult save(DocumentModel model)
        {
            /* if (model.document.ID == null || String.IsNullOrEmpty(model.document.ID))
             {
                 return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
             }*/
            // do you stuff

            docService.saveDocument(model.ID, model.content);

            //if (String.IsNullOrEmpty(model.content))
           // {
                //return RedirectToAction("Detail", "MovieApp", new { id = movieId });
                return Json(docService.getDocumentByID(model.ID).content, JsonRequestBehavior.AllowGet);

         //   }

         //   return RedirectToAction("../Project/ShowDocument/" + model.ID);

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
                var url = Url.RequestContext.RouteData.Values["id"].ToString();
                int urlInt = int.Parse(url);

                DocumentModel doc = new DocumentModel();
                doc = docFromUser;
                doc.name = docFromUser.name + "." + docFromUser.type.ToString();
                //Maybe add some default code in content
                doc.content = null;
                doc.projectID = urlInt;
                docService.addDocument(doc);

                return RedirectToAction("../Project/ShowDocument/" + doc.ID);
            }

            return View(docFromUser);
        }
     }
}