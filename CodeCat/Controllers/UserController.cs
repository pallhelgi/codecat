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
        private ProjectModel currProject = new ProjectModel();

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
            currProject = project;
            return View();
        }

        [HttpPost]
        public ActionResult share()
        {
            if (ModelState.IsValid)
            {
                //userService.share(user.email, project.ID);
                return RedirectToAction("../Dashboard/Dashboard");
            }

            return RedirectToAction("../Dashboard/Dashboard");
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