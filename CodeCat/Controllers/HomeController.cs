using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.Models;
using CodeCat.Services;

namespace CodeCat.Controllers
{
    public class HomeController : Controller
    {
        private UserService _user = new UserService();
        public ActionResult Index(FormCollection collection)
        {
            UserModel user = new UserModel();
            user.fullName = collection["signin"];
            string movieId = collection["form-signin"];
            Console.Write(user.fullName);

            return View();
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SignIn(FormCollection collection)
        {
            UserModel user = new UserModel();
            user.fullName = collection["form-signin"];
            string movieId = collection["form-signin"];
            Console.Write(user.fullName);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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

                _user.addUser(newUser);

                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}