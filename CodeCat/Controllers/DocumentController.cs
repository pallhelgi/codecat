using CodeCat.Models;
using CodeCat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.Models.ViewModels;
using System.Web.Services;

namespace CodeCat.Controllers
{
    public class DocumentController : Controller
    {
        DocumentService docService = new DocumentService(null);

        // GET: Document
        public ActionResult Index()
        {
            return View();
        }

        [WebMethod]
        public string save(DocumentModel DocumentModel)
        {
            try
            {
                docService.saveDocument(DocumentModel.ID, DocumentModel.content);
                DocumentModel check = docService.getDocumentByID(DocumentModel.ID);

                if(DocumentModel.content == check.content)
                {
                    return "success";
                }

                return "error";
            }
            catch
            {
                return "error";
            }
        }

        [HttpGet]
        public ActionResult addDocument(FormCollection collection)
        {
            return View();
        }

        [HttpPost]
        public ActionResult addDocument(DocumentModel docFromUser)
        {
            if(ModelState.IsValid)
            {
                //Get the projectID from the url
                var url = Url.RequestContext.RouteData.Values["id"].ToString();
                int urlInt = int.Parse(url);

                //Create the new doc
                DocumentModel doc = new DocumentModel();
                doc = docFromUser;
                doc.name = docFromUser.name + "." + docFromUser.type.ToString();
                doc.content = "//Code::Cat";
                doc.projectID = urlInt;
                bool success = docService.addDocument(doc);

                if(success == true)
                {
                    return RedirectToAction("../Project/ShowDocument/" + doc.ID);
                }
                else
                {
                    ModelState.AddModelError("name", "Oops, this project already has a document with this name!");

                    return View(docFromUser);
                }
            }

            return RedirectToAction("../Home/Error");
        }
    }
}