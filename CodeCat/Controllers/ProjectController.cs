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
        ProjectService projectService = new ProjectService(null);
        DocumentService documentService = new DocumentService(null);
        UserService userService = new UserService(null);

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
            SideBarViewModel sideView = new SideBarViewModel();

            viewModel.documents = projectService.getProject(id);
            ProjectModel model = projectService.getProjectById(id);
            viewModel.projectName = model.name;

            sideView.users = userService.getUsersSharingADocument(model.ID);
            viewModel.sidebar = sideView;

            viewModel.project = model;

            return View(viewModel);
        }

        public ActionResult showDocument(DocumentModel document)
        {
            //if document is empty:

            DocumentViewModel viewModel = new DocumentViewModel();
            viewModel.documents = projectService.getProject(document.projectID);

            viewModel.document = documentService.getDocumentByID(document.ID);

            DocumentModel model = documentService.getDocumentByID(document.ID);
            viewModel.documentName = model.name;
            ProjectModel p5Model = projectService.getProjectById(model.projectID);
            viewModel.docProjectName = p5Model.name;

            
            
            return View(viewModel);
        }

        [NoDirectAccess.NoDirectAccess]
        [HttpPost]
        public ActionResult showDocument(int id, int? projID)
        {
            DocumentViewModel viewModel = new DocumentViewModel();
            viewModel.document = documentService.getDocumentByID(id);
            DocumentModel model = documentService.getDocumentByID(id);

            viewModel.documentName = model.name;
            return View(viewModel);
           // return RedirectToAction("showDocument");
        }

        // public ActionResult showDocument()

        //This is probably not in use
        public ActionResult getDocuments(int projectID)
        {
            projectID = 1;
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.documents = projectService.getProject(projectID);

            return View(viewModel);
        }
        

        public ActionResult deleteDocument(DocumentModel document)
        {
            int projectID = documentService.getProjectIDByDocumentID(document.ID);
            documentService.deleteDocument(document.ID);

            return RedirectToAction("ShowProject/" + projectID);
        }
    }
}