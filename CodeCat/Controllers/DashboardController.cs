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
    [Authorize]
    public class DashboardController : Controller
    {
        ProjectService projectService = new ProjectService(null);
        UserService userService = new UserService(null);
        DocumentService docService = new DocumentService(null);

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult addProject()
        {
            return View();
        }

        public ActionResult deleteProject(ProjectModel project)
        {
            try
            {
                int projectID = project.ID;
                projectService.deleteProject(projectID);

                return RedirectToAction("Dashboard");
            }
            catch
            {
                return Content(Boolean.FalseString);
            }
        }

        [HttpPost]
        public ActionResult addProject(ProjectModel project)
        {
            if(ModelState.IsValid)
            {
                ProjectModel newProject = new ProjectModel
                {
                    name = project.name,
                };

                projectService.addProject(newProject, User.Identity.Name);
                DocumentModel firstDocument = new DocumentModel
                {
                    name = "index.",
                    content = "Code::Cat",
                    type = documentType.js,
                    projectID = newProject.ID
                };

                firstDocument.name = firstDocument.name + firstDocument.type.ToString();
                docService.addDocument(firstDocument);

                return RedirectToAction("../Project/ShowProject/" + firstDocument.projectID);
            }

           return View(project);
        }

        public ActionResult openProject()
        {
            return View();
        }

        [HttpGet]
        public ActionResult dashboard(int id = 3)
        {
            DashboardViewModel viewModel = new DashboardViewModel();
            viewModel.projects = projectService.getProjectFiltered(User.Identity.Name, id);

            return View(viewModel);
        }
    }
}