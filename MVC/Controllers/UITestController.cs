using MVC.DAL.GridMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UITestController : Controller
    {
        // GET: UITest
        public ActionResult TableFormat1()
        {
            //Datatables  with CommonSearch and Paging ,Sorting available by default
            return View();
        }
        public ActionResult TableFormat2()
        {
            //Datatables with CommonSearch, Column-wise searchTextBox and Paging
            // I customized in script tag part and style part and table to bring the Search text box in table head
            return View();
        }
        public ActionResult TableFormat3()
        {
            //Datatables with CommonSearch, Column-wise Distinct values Dropdown and Paging
            return View();
        }
        public ActionResult TableFormat4()
        {
            //Datatables with Export Options and Paging
            return View();
        }
        public ActionResult JqueryFormValidationPlugin()
        {
            //Using Jquery validation plugin/js files for Form validation - https://jqueryvalidation.org/documentation/
            return View();
        }
        public ActionResult ComplexForm()
        {
            return View();
        }
        public ActionResult DateElementJQandMomentvalidation()
        {
            //Also Date and Time Vale Datepicker
            return View();
        }
        public ActionResult GridMVC()
        {
            ////Type Grid.MVC in Nuhet Package Manager
            //EFImplDBEntities dbctx = new EFImplDBEntities();
            ////dbctx.ProfileDets.Select(i => new { i.ItemName, i.ItemType, i.ProfileID, i.Gender }).ToList();
            ////dbctx.ProfileDets.ToList();
            //return View(dbctx.ProfileDets.ToList());

            List<Client> Clients = new List<Client>() {        new Client { Id = 1, Name = "Julio Avellaneda", Email = "julito_gtu@hotmail.com" ,Dated=DateTime.Now},
        new Client { Id = 2, Name = "Juan Torres", Email = "jtorres@hotmail.com" ,Dated=DateTime.Now },
        new Client { Id = 3, Name = "Oscar Camacho", Email = "oscar@hotmail.com" ,Dated=DateTime.Now },
        new Client { Id = 4, Name = "Gina Urrego", Email = "ginna@hotmail.com" ,Dated=DateTime.Now },
        new Client { Id = 5, Name = "Nathalia Ramirez", Email = "natha@hotmail.com" ,Dated=DateTime.Now },
        new Client { Id = 6, Name = "Raul Rodriguez", Email = "rodriguez.raul@hotmail.com" ,Dated=DateTime.Now },
        new Client { Id = 7, Name = "Johana Espitia", Email = "johana_espitia@hotmail.com" ,Dated=DateTime.Now }
        };
            return View(Clients);
        }
    }
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Dated { get; set; }
    }
}