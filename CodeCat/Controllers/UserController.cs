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
        private ServiceBase baas = new ServiceBase();
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
        public ActionResult share(ApplicationUser user)
        {
            if (user.Email != null)
            {
                //The project ID is retrieved from the url
                var url = Url.RequestContext.RouteData.Values["id"].ToString();
                int urlInt = int.Parse(url);

                int check = 0;
                foreach(var us in userService._db.Users)
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
                    if(proj.name == userService.getProjectByID(urlInt).name)
                    {
                        ModelState.AddModelError("Email", "This user already has access to this project!");
                        return View(user);
                    }
                }

                userService.share(user.Email, urlInt);
                return RedirectToAction("../Dashboard/Dashboard");
            }

            return View();
           // return View(user);
        }


        public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUp(UserModel user)
        {
            //TODO
            //TODO
            if (ModelState.IsValid)
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
        }

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