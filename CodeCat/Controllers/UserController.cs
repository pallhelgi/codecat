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

        private UserService _user = new UserService();

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
            return View();
        }

        public ActionResult signUp()
        {
            //TODO
            return View();
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

        [HttpPost]
        public ActionResult createUser(UserModel user)
        {
            //TODO
            if(ModelState.IsValid)
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