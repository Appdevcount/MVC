using MVC.DAL.WebAPITester;
using MVC.Models.WebAPITester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers.WebAPITester
{
    public class CustomersController : Controller
    {
        // GET: Customer  
        public ActionResult Index()
        {
            DataAccess CC = new DataAccess();
            //ViewBag.listCustomers = CC.findAll();
            IEnumerable<Customer> Customers = CC.findAll();

            return View(Customers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Customer Cust)
        {
            DataAccess CC = new DataAccess();
            CC.Create(Cust);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DataAccess CC = new DataAccess();
            CC.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            DataAccess CC = new DataAccess();
            Customer cust = CC.find(id);
            return View("Details", cust);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DataAccess CC = new DataAccess();
            Customer Cust = new Customer();
            Cust = CC.find(id);
            return View("Edit", Cust);
        }
        [HttpPost]
        public ActionResult Edit(Customer Cust)
        {
            DataAccess CC = new DataAccess();
            CC.Edit(Cust);
            return RedirectToAction("Index");
        }
    }
}