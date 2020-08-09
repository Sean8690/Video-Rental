using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoRental.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Video rental is a web application built using ASP.NET MVC 5 using Entity Framework, APIs, and Single Page Application (SPA)";
            return View();
        }
    }
}