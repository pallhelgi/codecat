using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using CodeCat.Services;

namespace CodeCat.Controllers
{
    public class UserController : Controller
    {

        private UserService userService = new UserService(null);
        private ProjectService projectService = new ProjectService(null);

        [HttpGet]
        public ActionResult share(ProjectModel project)
        {
            project = projectService.getProjectById(project.ID);

            if (project != null)
            {
                return View();
            }
          
            return RedirectToAction("../Dashboard/Dashboard");
        }

        [HttpPost]
        public ActionResult share(ApplicationUser user)
        {
            if(user.Email != null)
            {
                //The project ID is retrieved from the url
                var url = Url.RequestContext.RouteData.Values["id"].ToString();
                int urlInt = int.Parse(url);

                //Check if the user already exists in the database
                int check = 0;
                foreach(var us in userService.getUsers())
                {
                    if(us.Email == user.Email)
                    {
                        check++;
                    }
                }

                if(check == 0)
                {
                    ModelState.AddModelError("Email", "Uh oh, this user does not exist!");

                    return View(user);
                }

                //Prevent double share
                List<ProjectModel> userProjects = projectService.getAllProjects(user.Email);
                foreach(var proj in userProjects)
                {
                    if(proj.name == projectService.getProjectById(urlInt).name)
                    {
                        ModelState.AddModelError("Email", "This user already has access to this project!");

                        return View(user);
                    }
                }

                userService.share(user.Email, urlInt);

                return RedirectToAction("../Project/ShowProject/" + urlInt);
            }

            return View("../Home/Error");
        }
    }
}