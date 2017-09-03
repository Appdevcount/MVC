using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class JSController : Controller
    {
        public ActionResult JS()
        {
            //From W3Schools[that includes BOM/HTML element manipulation] ,then Kudvenkat session
            return View();
        }
        // GET: JS
        public ActionResult JSFormElement1()
        {
            // Drop down Option hide tester using jquery script
            return View();
        }
        public ActionResult W3schoolsJQuery()
        {
            return View();
        }
        public ActionResult JQueryUI()
        {
            return View();
        }
    }
}