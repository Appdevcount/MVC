using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.WebPages.Html;
using System.Web.Mvc;

namespace MVC.Models
{
    //    Check the ~\App_Start\BundleConfig.cs file to include the following line
    //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
    //            "~/Scripts/jquery.validate.unobtrusive*",
    //            "~/Scripts/jquery.validate*"));
    public class ViewModel
    {
        //Numeric
        public int ID { get; set; }
        //TextBox
        [DataType(DataType.Text, ErrorMessage = "Enter only this type of value")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Value length should be like this")]
        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; }
        //Password
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8)]
        [Required()]
        public string Password { get; set; }
        //ConfPwd
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password doesnot match")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8)]
        [Required()]
        public string ConfirmPassword { get; set; }
        //Email
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        [Required()]
        public string Email { get; set; }
        //Price
        [Display(Name = "Price")]
        [DataType(DataType.Currency, ErrorMessage = "Only currency values allowed like ...")]
        public double ListPrice { get; set; }
        //Phone
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Mobile number should be like this")]
        [StringLength(32)]
        public string Phone { get; set; }
        //Date
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        //TextArea
        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessage = "Max length is this much only")]
        public string Remarks { get; set; }
        //===========================================================================================================
        //DrpdownList //Edit value?
        //@Html.ValidationSummary(true, "", new { @class = "text-danger" })
        //<div class="form-group">
        //            @Html.LabelFor(model => model.Country, htmlAttributes: new { @class = "control-label col-md-2" })
        //            <div class="col-md-10">
        //                @Html.DropDownListFor(model => model.Country, Model.CountryList, "Select Country", new { @class = "form-control", @id = "Country" })
        //                @Html.ValidationMessageFor(model => model.Country, "", new { @class = "text-danger" })
        //        </div>
        //</div>
        [Required(ErrorMessage = "Country Field is required")]
        public string Country { get; set; } //DDL Value can be int or string
        //HardCode Population of DDL //Property Get source 
        public List<SelectListItem> CountryList
        {
            get
            {
                List<SelectListItem> LI = new List<SelectListItem>();
                LI.Add(new SelectListItem { Text = "Kuwait", Value = "Kuwait" });
                LI.Add(new SelectListItem { Text = "Sudan", Value = "Sudan" });
                return LI;
            }
        }
        //From Datasource Population of DDL// Method source , so can try with static keyword or without
        //public static IEnumerable<SelectListItem> CountryList()
        //{
        //    var FE = new FormEntities();
        //    var countries = FE
        //                .Country
        //                .Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.CountryID.ToString(),
        //                            Text = x.Country
        //                        });
        //    return new SelectList(countries, "Value", "Text");
        //}
        //===========================================================================================================
        //CheckboxList //Edit value? - Plugin https://www.codeproject.com/Tips/786243/ASP-NET-MVC-CheckBoxList-Basic-Implementation   https://www.codeproject.com/Tips/613785/How-to-Use-CheckBoxListFor-With-ASP-NET-MVC
        //No default Data annotation for validation so need to build custom validation at server side or client side
        //Validation is not working but since its least used control , it can be managed easily with Jquery validation plugin or manually jquery validation
        //Manual/usual way of binding in CheckboxList
        //@foreach(var g in Model.AllGroups)
        //{
        //        < li >
        //            < input type = "checkbox"
        //            name = "SelectedGroups"
        //            value = "@g.ID" id = "@g.ID"
        //    @{
        //        if (Model.SelectedGroups.Contains(g.ID))
        //        { < text > checked= 'checked' </ text >  }
        //    } />
        //            < label for= "@g.ID" > @g.Name </ label >
        //        </ li >
        //}
        //Using MVCCheckboxlist Nuget library
        //<div class="editor-field">
        //    @Html.CheckBoxListFor(model=>model.SelectedGroups,
        //                          model=>model.AllGroups,
        //                          x=>x.ID,
        //                          x=>x.Name,
        //                          model=>model.UserGroups)
        //</div>
        //@Html.CheckBoxListFor(model => model.PostedFruits.FruitIds,
        //                          model => model.AvailableFruits,
        //                          fruit => fruit.Id,
        //                          fruit => fruit.Name,
        //                          model => model.SelectedFruits,
        //                          Position.Horizontal)
        [ValidateCheckBoxCollectionAttribute(ErrorMessage = "Atleast one need to be checked .. or take validation out")]//Annotation applicable for this property as it takes the actual values to model back
        public CheckBoxFruits CheckBoxFruitsModel { get; set; } 
        //===========================================================================================================
        //RadiobuttonList //Edit value?
        //This strongly Typed Datasource can be used for Radiobutton Lists  - Works in same way as Dropdownlist but with with 
        //manual DOM/Radiobutton element Construction repetetively like Listbox . so property to be used in the ViewModel is string/Int
        //@foreach(var RB in Model.GenderRadioButtonList)
        //{
        //    @Html.RadioButtonFor(model => model.Gender, Rd.Value) 
        //    @Html.Label(Rd.Text)
        //}
        [Required(ErrorMessage = "Gender Field is required")]
        public string Gender { get; set; } //RBL Value can be int or string
        //HardCode Population of RBL //Property Get source 
        public List<SelectListItem> GenderRadioButtonList//Radio Available options defined in View Model
        {
            get
            {
                return new List<SelectListItem>{ new SelectListItem { Text = "WEB", Value = "C#" },
                 new SelectListItem { Text = "WINDOWS", Value = "WINDOWS" },
                 new SelectListItem { Text = "API", Value = "API" } };
            }
        }
        //From Datasource Population of RBL// Method source , so can try with static keyword or without
        //public static IEnumerable<SelectListItem> CountryList()
        //{
        //    var FE = new FormEntities();
        //    var countries = FE
        //                .Country
        //                .Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.CountryID.ToString(),
        //                            Text = x.Country
        //                        });
        //    return new SelectList(countries, "Value", "Text");
        //}
        //===========================================================================================================

        //ListBox Multiple Selection - Follows same as CHECKBOXlist - Can be implemented as its easy and mostly not required in future //Edit value?
        //FileUpload //Edit value?

    }

    //Server Side Validation - Data annotation for Checkbox
    //==========================================================
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidateCheckBoxCollectionAttribute : ValidationAttribute
    {
        //public override bool IsValid(object value)
        //{
        //    return value != null && value is bool && (bool)value;
        //    //return base.IsValid(value);
        //}
        // Validation logic for server side goes here
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // do some if else conditions
            //if (validationContext.Items.Count > 0) { return new ValidationResult("Server side validation message demo.>0"); }
            //else { return new ValidationResult("Server side validation message demo.<0"); }
            return new ValidationResult("Server side validation message demo");
        }
    }
    public class Fruit
    {
        //Integer value of a checkbox
        public int Id { get; set; }
        //String name of a checkbox
        public string Name { get; set; }
        //Boolean value to select a checkbox on the list
        public bool IsSelected { get; set; }

    }
    public class CheckBoxFruits
    {
        public IEnumerable<Fruit> AllFruits { get; set; }
        //[ValidateCheckBoxCollectionAttribute(ErrorMessage = "Atleast one need to be checked .. or take validation out")]//Annotation applicable for this property as it takes the actual values to model back
        public IEnumerable<Fruit> SelectedFruits { get; set; }
        [ValidateCheckBoxCollectionAttribute(ErrorMessage = "Atleast one need to be checked .. or take validation out")]//Annotation applicable for this property as it takes the actual values to model back
        //public int[] PostedNewlyUpdatedFruitIDs { get; set; }
        public IEnumerable<int> PostedNewlyUpdatedFruitIDs { get; set; }
    }

    public class CRUDInputControlUtilities //These can be present in App Module instead of DAL.Infrastructure module as it is NOT the Final DB operation for the functionality
    {
        //This method is to utilize to get Intial model for all Fruits available in Create operation
        public CheckBoxFruits GetFruitsInitialModel()
        {
            var model = new CheckBoxFruits();
            var selectedFruits = new List<Fruit>();
            model.AllFruits = GetAllFruits();
            model.SelectedFruits = selectedFruits;
            //model.PostedNewlyUpdatedFruitIDs = new int[0];
            model.PostedNewlyUpdatedFruitIDs =  new int[0];
            return model;
        }
        public static IEnumerable<Fruit> GetAllFruits()
        {
            return new List<Fruit> {
                              new Fruit {Name = "Apple", Id = 1 },
                              new Fruit {Name = "Banana", Id = 2},
                              new Fruit {Name = "Cherry", Id = 3},
                              new Fruit {Name = "Pineapple", Id = 4},
                              new Fruit {Name = "Grape", Id = 5},
                              new Fruit {Name = "Guava", Id = 6},
                              new Fruit {Name = "Mango", Id = 7}
                            };
        }

        //This method is to utilize for Create operation POST method to save values-CHECKBOX
        public List<Fruit> GetNewlySelectedFruitsModel(int[] PostedNewlySelectedFruitIDs)
        {
            var NewlySelectedFruits = new List<Fruit>();

            if (PostedNewlySelectedFruitIDs == null)
            {
                PostedNewlySelectedFruitIDs = new int[0];
            }
            else if (PostedNewlySelectedFruitIDs != null && PostedNewlySelectedFruitIDs.Any())// if  array of NewlyUpdatedFruitIDs exists and is not empty,save selected ids and create a list of fruits with that
            {
                NewlySelectedFruits = GetAllFruits()
                                 .Where(x => PostedNewlySelectedFruitIDs.Any(s => x.Id.ToString().Equals(s)))
                                 .ToList();
            }
            return NewlySelectedFruits;
        }
        //This method is to utilize for Edit operation GET method to fetch selected values to form - CHECKBOX
        private CheckBoxFruits GetAlreadySelectedFruitsModel(int[] PostedUpdatedFruitIDs)
        {
            var model = new CheckBoxFruits();
            var NewlyUpdatedFruits = new List<Fruit>();

            if (PostedUpdatedFruitIDs == null)
            {
                PostedUpdatedFruitIDs = new int[0];
            }
            else if (PostedUpdatedFruitIDs != null && PostedUpdatedFruitIDs.Any()) // if  array of NewlyUpdatedFruitIDs exists and is not empty,save selected ids and create a list of fruits with that
            {
                NewlyUpdatedFruits = GetAllFruits()
                                 .Where(x => PostedUpdatedFruitIDs.Any(s => x.Id.ToString().Equals(s)))
                                 .ToList();
            }

            model.AllFruits = GetAllFruits();
            model.SelectedFruits = NewlyUpdatedFruits;
            model.PostedNewlyUpdatedFruitIDs = PostedUpdatedFruitIDs;
            return model;
        }


    }
}

//private CheckBoxFruits GetNewlySelectedFruitsModel(int[] PostedNewlySelectedFruitIDs)
//{
//    var model = new CheckBoxFruits();
//    var NewlyUpdatedFruits = new List<Fruit>();

//    if (PostedNewlySelectedFruitIDs == null)
//    {
//        PostedNewlySelectedFruitIDs = new int[0];
//    }
//    else if (PostedNewlySelectedFruitIDs != null && PostedNewlySelectedFruitIDs.Any())             // if  array of NewlyUpdatedFruitIDs exists and is not empty,save selected ids and create a list of fruits with that
//    {
//        NewlyUpdatedFruits = GetAllFruits()
//                         .Where(x => PostedNewlySelectedFruitIDs.Any(s => x.Id.ToString().Equals(s)))
//                         .ToList();
//    }

//    model.AllFruits = GetAllFruits();
//    model.SelectedFruits = NewlyUpdatedFruits;
//    model.PostedNewlyUpdatedFruitIDs = PostedNewlySelectedFruitIDs;
//    return model;
//}
