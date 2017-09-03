using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BootstrapTestController : Controller
    {
        // GET: BootstrapTest
        public ActionResult getBootstrap()
        {
            return View();
        }
        public ActionResult W3SchoolsBootstrap()
        {
            return View();
        }
        public ActionResult TutorialsPointBootstrap()
        {
            return View();
        }
        public ActionResult KudBootstrap()
        {
            return View();
        }
        public ActionResult KudBootstrapHScrollspy()
        {
            //Horizontal scrollspy
            return View();
        }
        public ActionResult KudBootstrapVScrollspy()
        {
            //Vertical scrollspy
            return View();
        }
    }
}