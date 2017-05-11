using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeCat.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}