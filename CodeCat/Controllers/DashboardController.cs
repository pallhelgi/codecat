using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.Models.ViewModels;
using CodeCat.TestClasses;
using CodeCat.Services;

namespace CodeCat.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        ProjectService projectService = new ProjectService();
        UserService userService = new UserService();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
            //TODO

        [HttpGet]
        public ActionResult addProject()
        {
            //TODO
            return View();
        }

        [HttpPost]
        public ActionResult addProject(ProjectModel project)
        {     
            if (ModelState.IsValid)
            {
                ProjectModel newProject = new ProjectModel
                {
                    name = project.name,
                    //  creatorUserID = projectService.getProjectCreator();

                 };

                DocumentModel firstDocument = new DocumentModel
                {
                    name = "index.js",
                    content = null
                };
                
                projectService.addProject(newProject, User.Identity.Name);

                return RedirectToAction("Dashboard");

            }
                

           return View(project);
        }

        [HttpGet]
        public ActionResult addUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                userService.share(user.email, 3);
                return RedirectToAction("Dashboard");

            }

            return View(user);
        }

        public ActionResult share(UserModel user)
        {
            //TODO
            return View();
        }

        public ActionResult openProject()
        {
            //TODO
            return View();
        }

        public ActionResult Dashboard()
        {
            DashboardViewModel viewModel = new DashboardViewModel();
            //testClass test = new testClass();
            viewModel.projects = projectService.getUserProjects(User.Identity.Name);
            //viewModel.projects = test.SeedProject();

            return View(viewModel);
        }
    }
}