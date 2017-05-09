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

        public ActionResult showDocument(ProjectModel project)
        {
            //if document is empty:
            if(project == null)
            {
                string Code = "Hello my friend, I'm ProjectController" + Environment.NewLine;
                Code += Environment.NewLine;
                Code += '\t' + "//This is your javascript code" + Environment.NewLine;
                Code += Environment.NewLine;
                Code += '\t' + "function foo(items) {" + Environment.NewLine;
                Code += "\t\t" + "var x = 'I am Code::Cat'" + Environment.NewLine;
                Code += "\t\t" + "return x;" + Environment.NewLine;
                Code += '\t' + "}" + Environment.NewLine;
            
                ViewBag.Code = Code;
            }
            else
            {
                DocumentViewModel viewModel = new DocumentViewModel();
                viewModel.documents = projectService.getProject(project.ID);

                var url = Url.RequestContext.RouteData.Values["ID"].ToString();
                int docID = int.Parse(url);
                
                var content = documentService.getDocument(docID);

                ViewBag.Code = content;
                ViewBag.DocumentID = docID;
                return View(viewModel);
            }
            

            //else: get Document from DB and fill Ace with the string
 

            return View();
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