using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CSSController : Controller
    {
        // GET: CSS
        public ActionResult cssw3schoolselements()
        {
            //w3schools elements
            return View();
        }
        public ActionResult cssw3schoolsnavvert()
        {
            //w3schools navigation  vertical 
            return View();
        }
        public ActionResult cssw3schoolsnavhorz()
        {
            //w3schools navigation  horizontal 
            return View();
        }
    }
}