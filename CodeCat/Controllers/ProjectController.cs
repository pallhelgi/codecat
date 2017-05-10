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
            ProjectModel model = projectService.getProjectById(id);
            viewModel.projectName = model.name;
            return View(viewModel);
        }

        public ActionResult showDocument(DocumentModel document)
        {
            //if document is empty:

            DocumentViewModel viewModel = new DocumentViewModel();
            viewModel.documents = projectService.getProject(document.projectID);

            viewModel.document = documentService.getDocumentByID(document.ID);

            //else: get Document from DB and fill Ace with the string
            //this is my code:
            DocumentModel model = documentService.getDocumentByID(document.ID);
            viewModel.documentName = model.name;
            ProjectModel p5Model = projectService.getProjectById(model.projectID);
            //ProjectModel p4Model = projectService.getProjectByID(document.projectID);
            //ProjectModel p3Model = projectService.getProjectById(document.projectID);
            //ProjectModel p2Model = documentService.getProjectByID(document.projectID);
            //ProjectModel pModel = documentService.getProjectByID(document.ID);
            viewModel.docProjectName = p5Model.name;
            //
            return View(viewModel);




        }

        [NoDirectAccess.NoDirectAccess]
        [HttpPost]
        public ActionResult showDocument(int id, int? projID)
        {
            DocumentViewModel viewModel = new DocumentViewModel();
            viewModel.document = documentService.getDocumentByID(id);
            DocumentModel model = documentService.getDocumentByID(id);


            //viewModel.documents = projectService.getProject(id);
            //ProjectModel model = projectService.getProjectById(id);
            //viewModel.projectName = model.name;

            viewModel.documentName = model.name;
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