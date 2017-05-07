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
            //if document is empty:
            string Code = "Hello my friend, I'm ProjectController" + Environment.NewLine;
            Code += Environment.NewLine;
            Code += '\t' + "//This is your javascript code" + Environment.NewLine;
            Code += Environment.NewLine;
            Code += '\t' + "function foo(items) {" + Environment.NewLine;
            Code += "\t\t" + "var x = 'I am Code::Cat'" + Environment.NewLine;
            Code += "\t\t" + "return x;" + Environment.NewLine;
            Code += '\t' + "}" + Environment.NewLine;
            
            ViewBag.Code = Code;

            //TODO: else: get Document and fill Ace with the string
            return View();
        }

        public ActionResult showDocuments(int projectID)
        {
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.documents = projectService.getProject(projectID);

            return View(viewModel);
        }
    }
}