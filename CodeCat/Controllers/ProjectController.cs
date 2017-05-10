﻿using CodeCat.Models;
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

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult showDocument(int id, int? projID)
        {

            DocumentViewModel viewModel = new DocumentViewModel();
            viewModel.document = documentService.getDocumentByID(id);
<<<<<<< HEAD
=======
            if(projID != null)
            {
                //int.Parse(projID);
            }
            //viewModel.documents = projectService.getProject(projID);
>>>>>>> ffc651604b6282d8a745a42b21592a13c1468e92

            return View(viewModel);
        }

        // public ActionResult showDocument()

        public ActionResult getDocuments(int projectID)
        {
            projectID = 1;
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.documents = projectService.getProject(projectID);

            return View(viewModel);
        }
    }
}