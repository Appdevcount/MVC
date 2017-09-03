using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EFBoardController : Controller
    {
        // GET: EFBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}