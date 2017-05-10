using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.Models.ViewModels;
using CodeCat.Services;

namespace CodeCat.Controllers
{
    public class ProjectController : Controller
    {
        ProjectService projectService = new ProjectService();
        DocumentService documentService = new DocumentService();
        // GET: Project
        public ActionResult Index()
        {
            //TODO

            return View();
        }

        public ActionResult share(UserModel user)
        {
            //TODO
            return View();
        }

        [NoDirectAccess.NoDirectAccess]
        public ActionResult showProject(int id)
        {
            ProjectViewModel viewModel = new ProjectViewModel();
            //testClass test = new testClass();
            //viewModel.projects = projectService.getUserProjects(User.Identity.Name);
            //viewModel.projects = test.SeedProject();
            viewModel.documents = projectService.getProject(id);

            return View(viewModel);
        }

        public ActionResult showDocument(DocumentModel document)
        {
            //if document is empty:

            DocumentViewModel viewModel = new DocumentViewModel();
            viewModel.documents = projectService.getProject(document.projectID);

            viewModel.document = documentService.getDocumentByID(document.ID);

            //else: get Document from DB and fill Ace with the string

            return View(viewModel.document);
        }

        [NoDirectAccess.NoDirectAccess]
        [HttpPost]
        public ActionResult showDocument(int id, int? projID)
        {
            if (Request.ServerVariables["HTTP_REFERER"].ToLower().IndexOf("http://localhost:2992") == -1)
            {
                // Not from my site
                Response.Redirect("NotAllowed.aspx");
            }

            DocumentViewModel viewModel = new DocumentViewModel();
            viewModel.document = documentService.getDocumentByID(id);

            return View(viewModel);
           // return RedirectToAction("showDocument");
        }

        // public ActionResult showDocument()

        public ActionResult getDocuments(int projectID)
        {
            projectID = 1;
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.documents = projectService.getProject(projectID);

            return View(viewModel);
        }
        

        public ActionResult deleteDocument(DocumentModel document)
        {
            int projectID = documentService.getProjectByDocumentID(document.ID);
            documentService.deleteDocument(document.ID);

            return RedirectToAction("ShowProject/" + projectID);
        }
    }
}