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
        DocumentService docService = new DocumentService();
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

        public ActionResult deleteProject(ProjectModel project)
        {
            int projectID = project.ID;

            projectService.deleteProject(projectID);

            return RedirectToAction("Dashboard");
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

/*        [HttpGet]
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
*/
        public ActionResult openProject()
        {
            //TODO
            return View();
        }

        [HttpGet]
        public ActionResult Dashboard(int id = 3)
        {
            DashboardViewModel viewModel = new DashboardViewModel();
            viewModel.projects = projectService.getProjectFiltered(User.Identity.Name, id);

            return View(viewModel);
        }
    }
}