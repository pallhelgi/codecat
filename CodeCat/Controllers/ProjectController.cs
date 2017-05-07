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

        public ActionResult showDocument()
        {
            //TODO
        
            
            return View();
        }

        public ActionResult getDocuments(int projectID)
        {
            projectID = 1;
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.documents = projectService.getProject(projectID);

            return View(viewModel);
        }
    }
}