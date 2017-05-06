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
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
            //TODO

        [HttpGet]
        public ActionResult addProject()
        {
<<<<<<< HEAD
            //TODO

=======
>>>>>>> abebd7b4e78fb6d3bf9324694e648066e5469897
            return View();
        }

        [HttpPost]
        public ActionResult addProject(int creatorUserID, ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                ProjectModel newProject = new ProjectModel
                {
                    ID = 4,
                    name = "SUCCESS",
                    creatorUserID = 1
                };
                projectService.addProject(newProject);

                return RedirectToAction("Dashboard");
            }

            return View(project);
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
            testClass test = new testClass();
            viewModel.projects = projectService.getAllProjects();
            //viewModel.projects = test.SeedProject();

            return View(viewModel);
        }
    }
}