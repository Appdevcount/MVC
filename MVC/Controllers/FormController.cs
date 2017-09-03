using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Xml.Serialization;
using System.Text;
using System.Data.SqlClient;
using MVC.Models;

namespace MVC.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult FORM()
        {
            //FORMmodel fm = new FORMmodel();

            //fm.DDMobileBrand.Add(new SelectListItem { Text = "a", Value = "av" });
            //fm.DDMobileBrand.Add(new SelectListItem { Text = "b", Value = "bv" });

            //List<SelectListItem> DDMobileBrand = new List<SelectListItem>();
            //DDMobileBrand.Add(new SelectListItem { Text = "a", Value = "av" });
            //DDMobileBrand.Add(new SelectListItem { Text = "b", Value = "bv" });

            //SelectListItem DDMobileBrandsl = new SelectListItem();
            //DDMobileBrandsl.Text = "a";
            //DDMobileBrandsl.Value = "av";;

            //fm.DDMobileBrand.Add(new SelectListItem { Text = "a", Value = "av" });
            //===================================

            //fm.CHKMobileBrandlist.Add(new CHKMobileBrandModel { id=1, name="chk1", @checked=true});
            //fm.CHKMobileBrandlist.Add(new CHKMobileBrandModel { id = 2, name = "chk2", @checked = true });

            //===================

            FORMmodel fmm = new FORMmodel();
            var list = new List<CHKMobileBrandModel>();
            SqlConnection cn = new SqlConnection("Data Source=IKW-PC;Initial Catalog=VASTest;Integrated Security=True");
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("select chkid,chkname,chkchecked FROM MVCchkMobileBrands", cn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new CHKMobileBrandModel { id = rdr.GetInt32(0), name = rdr.GetString(1), @checked = rdr.GetBoolean(2) });
                    }
                    fmm.DDMobilBrandDB = new SelectList(list, "ID", "Name");// list;
                }
            }
            cn.Close();
            //list.Add(new CHKMobileBrandModel { id = 1, name = "A" });
            //list.Add(new CHKMobileBrandModel { id = 2, name = "B" });
            //fmm.DDMobilBrandDB = new SelectList(list);

            return View(fmm);

            //return View();
        }
        //public static List<SelectListItem> DDL()
        //{
        //    List<SelectListItem> DDMobileBrand = new List<SelectListItem>();
        //    DDMobileBrand.Add(new SelectListItem { Text = "a", Value = "av" });
        //    DDMobileBrand.Add(new SelectListItem { Text = "b", Value = "bv" });

        //    return DDMobileBrand;
        //}
        [HttpPost]
        public ActionResult Form(FORMmodel fm)
        {

            // bool a, b, c;
            // List<int> l = new List<int>(); 
            // arr

            //foreach (CHKMobileBrandModel ch in fm.CHKMobileBrandlist)
            // {
            //     if (ch.@checked = true )

            //if (ch.id.Equals(1))
            //{ a = true; }
            //    else if(ch.id.Equals(2))
            //{ b = true; }
            //    else
            //{ c = true; }

            //l.Add(c.id);
            //}
            //XmlSerializer x=new XmlSerializer().Serialize()
            //byte[] postBytes = Encoding.UTF8.GetBytes()

            return View(fm);
        }
        public ActionResult PartialAjaxModalProfile()
        {
            AjaxModalContext dbctx = new AjaxModalContext();
            ProfileViewModel pvm = new ProfileViewModel { proflist = dbctx.Profile.ToList(), Prof = new Profile() };

            return View(pvm);
        }
        public ActionResult PartialAjaxModal(int Id)
        {
            System.Threading.Thread.Sleep(3000);
            //Have implemented both PartialView based Modal and Same Page modal with .. Child Modal and data pass from Child to Parent Modal Form fields
            //Server side validation was not working in Partial View modal - so for that it was need to make jquery.validate.* references directly in the partial view as well
            Profile p = new Profile();
            return PartialView("ProfilePartialForm", p);
            //return PartialView("ProfilePartialForm");

        }
        [HttpPost]
        public ActionResult PartialAjaxModal(ProfileViewModel Prof, HttpPostedFileBase DocFiled)
        {
            //System.Threading.Thread.Sleep(3000);
            ViewBag.Status = "FromACTION " + DocFiled.FileName + DocFiled.ContentType + DocFiled.ContentLength;
            //return PartialView("ProfilePartialForm");
            return PartialView("StatusBox");

        }
        public ActionResult ModalTest()
        {
            return View();
        }
        public ActionResult CheckboxListTEST()
        {
            CheckModel cm = new CheckModel();
            return View(cm);
        }
        [HttpPost]
        public ActionResult CheckboxListTEST(CheckModel Prof)
        {
            CheckModel cm = new CheckModel();
            return View(cm);
        }
        public ActionResult CheckboxListpoc()
        {
            CheckModelpoc cm = new CheckModelpoc();
            return View(cm);
        }
        [HttpPost]
        public ActionResult CheckboxListpoc(CheckModelpoc cmpoc, IEnumerable<string> StaticMultiBoxes)
        {
            CheckModelpoc cm = new CheckModelpoc();
            return View(cm);
        }
        [HttpGet]
        public ActionResult CreateViewModel()
        {
            //View Model with Data Annotation for Validation
            ViewModel vm = new ViewModel();
            CRUDInputControlUtilities cicu = new CRUDInputControlUtilities();
            vm.CheckBoxFruitsModel = cicu.GetFruitsInitialModel();
            return View(vm);
        }
        [HttpPost]
        public ActionResult CreateViewModel(ViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "");
            //    ViewModel vmr = new ViewModel();
            //    CRUDInputControlUtilities cicu = new CRUDInputControlUtilities();
            //    vmr.CheckBoxFruitsModel = cicu.GetFruitsInitialModel();
            //    return View(vmr);
            //}
            //else
            //{
            //    //View Model with Data Annotation for Validation
            //    return View();
            //}
            return View();
        }
        [HttpGet]
        public ActionResult EditViewModel()
        {
            //View Model with Data Annotation for Validation
            return View();
        }
        [HttpPost]
        public ActionResult EditViewModel(ViewModel vm)
        {
            //View Model with Data Annotation for Validation
            return View();
        }

    }
}