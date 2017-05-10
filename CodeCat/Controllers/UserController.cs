using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.Services;

namespace CodeCat.Controllers
{
    public class UserController : Controller
    {

        private UserService userService = new UserService();
        private ProjectService projectService = new ProjectService();
        // GET: User
        public ActionResult Index()
        {
            //TODO
            return View();
        }

        public ActionResult listUsers(int ProjectID)
        {
            //TODO
            return View();
        }

        public ActionResult signIn()
        {
            //TODO
            Console.Write("hi");
            return View();
        }

        [HttpGet]
        public ActionResult share(ProjectModel project)
        {
           

                project = projectService.getProjectById(project.ID);

                if (project != null)
                {
                    return View();
                }
          

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult share(UserModel user)
        {
            if (user.email != null)
            {
                //The project ID is retrieved from the url
                var url = Url.RequestContext.RouteData.Values["id"].ToString();
                int urlInt = int.Parse(url);

                //Check if user is already in database
                if(projectService.getuserByID(user.ID) == null)
                {
                    return View(user);
                }

                //Prevent double share
                List<ProjectModel> userProjects = projectService.getAllProjects(user.email);
                foreach(var proj in userProjects)
                {
                    if(proj.name == userService.getProjectByID(urlInt).name)
                    {
                        ModelState.AddModelError(user.email, "YOU FAIL");
                        return View(user);
                    }
                }

                userService.share(user.email, urlInt);
                return RedirectToAction("../Dashboard/Dashboard");
            }

            return View();
           // return View(user);
        }


        /*public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUp(UserModel user)
        {
            //TODO
            //TODO
            /*if (ModelState.IsValid)
            {
                UserModel newUser = new UserModel();
                newUser.ID = user.ID;
                newUser.fullName = user.fullName;
                newUser.username = user.username;
                newUser.email = user.email;
                newUser.password = user.password;

                userService.addUser(newUser);

                return RedirectToAction("Index");
            }

            return View(user);
        }*/

        public ActionResult forgottenPassword()
        {
            //TODO
            return View();
        }

        public ActionResult createUser()
        {
            //TODO
            return View();
        }
    }
}