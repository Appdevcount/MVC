using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class ProfileViewModel
    {
        public Profile Prof { get; set; }
        public IEnumerable<Profile> proflist { get; set; }
        [ValidateCheckCollection(ErrorMessage = "TEST")]
        public IEnumerable<string> Checkboxlist { get; set; }

        public List<SelectListItem> SkillsetSources//CheckBoxlist Available options defined in View Model
        {
            get
            {
                return new List<SelectListItem>{ new SelectListItem { Text = "WEB", Value = "C#",Selected=false },
                 new SelectListItem { Text = "WINDOWS", Value = "WINDOWS" ,Selected=false},
                 new SelectListItem { Text = "API", Value = "API" ,Selected=false} };
            }
        }
        public List<SelectListItem> InterestedDomainBoxsources//Listbox Available options defined in View Model
        {
            get
            {
                return new List<SelectListItem>{ new SelectListItem { Text = "WEB", Value = "C#" },
                 new SelectListItem { Text = "WINDOWS", Value = "WINDOWS" },
                 new SelectListItem { Text = "API", Value = "API" } };
            }
        }
        public List<SelectListItem> RadioEditorBox//Radio Available options defined in View Model
        {
            get
            {
                return new List<SelectListItem>{ new SelectListItem { Text = "WEB", Value = "C#" },
                 new SelectListItem { Text = "WINDOWS", Value = "WINDOWS" },
                 new SelectListItem { Text = "API", Value = "API" } };
            }
        }
        public List<SelectListItem> CheckEditorBox//CheckBoxlist Available options defined in View Model
        {
            get
            {
                return new List<SelectListItem>{ new SelectListItem { Text = "WEB", Value = "C#" },
                 new SelectListItem { Text = "WINDOWS", Value = "WINDOWS" },
                 new SelectListItem { Text = "API", Value = "API" } };
            }
        }
        public List<SelectListItem> NewsTopicsources//Check Available options defined in View Model
        {
            get
            {
                return new List<SelectListItem>{ new SelectListItem { Text = "WEB", Value = "C#" },
                 new SelectListItem { Text = "WINDOWS", Value = "WINDOWS" },
                 new SelectListItem { Text = "API", Value = "API" } };
            }
        }
        //Dropdownlist and ListBox
        //===========================
        //This strongly Typed Datasource Can be used for Dropdownlist and ListBox[ Multiselect by default] - Exposing Datasource as List<SlectListItem> or 
        //IEnnumerable<SelectListItem>
        //==============================================================================================================
        //private IEnumerable<SelectListItem> GetCountry()
        //{
        //    var FE = new FormEntities();
        //    var countries = FE
        //                .Country
        //                .Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.UserRoleId.ToString(),
        //                            Text = x.UserRole
        //                        });
        //    return new SelectList(countries, "Value", "Text");
        //}
        ////OR
        //private IEnumerable<SelectListItem> GetCountries()
        //{
        //    var FE = new FormEntities();
        //    var countries = FE
        //                .Country
        //                .Select(x => new Country { CID = x.CID, CCDE = x.CCDE });
        //    return new SelectList(countries, "CID", "CCDE");
        //}
        //@Html.LabelFor(m=>m.SelectedFlavorId)
        //@Html.DropDownListFor(m => m.Country, Model.Countries)
        //@Html.ValidationMessageFor(m=>m.Country)

        //@Html.LabelFor(model => model.Prof.Country, htmlAttributes: new { @class = "control-label col-md-2" })
        //                        @Html.DropDownListFor(model => model.Prof.Country, new List<SelectListItem> { new SelectListItem { Text="A",Value="A" },
        //                   new SelectListItem { Text="B",Value="B" },
        //                   new SelectListItem { Text="C",Value="C" },
        //                   new SelectListItem { Text="D",Value="D" },
        //                   new SelectListItem { Text="E",Value="E" },
        //                   new SelectListItem { Text="F",Value="F" },
        //                   new SelectListItem { Text="G",Value="G" },
        //                   new SelectListItem { Text="H",Value="H" },
        //                   new SelectListItem { Text="I",Value="I" }},"Select Country", new { htmlAttributes = new { @class = "form-control" } })
        //                        @Html.ValidationMessageFor(model => model.Prof.Country, "", new { @class = "text-danger" })

        //@Html.ListBoxFor(m => m.Country, Model.Countries, new { size = 8 })

        //For Listbox the data received as Array of selected values as below, so Viewmodel has to have a integer/string array property or 
        //public IEnumerable<string> SelectItems { set; get; }. The actual Code first property will be ICollection of Object
        //[HttpPost]
        //public ActionResult Form(string[] Countries)
        //{
        //List<ClassLibraryProject.EFDF.ItemInterest> mcc = new List<ClassLibraryProject.EFDF.ItemInterest>();
        //    foreach (string Country in Countries)
        //    {
        //        ClassLibraryProject.EFDF.ItemInterest mc = new ClassLibraryProject.EFDF.ItemInterest();
        //            mc.InterestedTopic = ml.Text;
        //            //mc.ProfileDetId = 1;
        //            mcc.Add(mc);
        //    }
        ////}
        //or
        //[HttpPost]
        //public string Form(IEnumerable<string> SelectItems)
        //{
        //    if (SelectItems != null)
        //    {
        //        return string.Join(",", SelectItems);
        //    }
        //    else
        //    {
        //        return "No vaues are selected";
        //    }
        //}

        //For Dropdownlist the data received as string single value and can easily map to a property in model as below


        //Checkbox Lists
        //==============
        //This strongly Typed Datasource can be used for Checkbox Lists  - Works in same way as ListBox but with manual DOM/Checbox element Construction. 
        //To avoid this , can opt for Custom HTML Helper
        //==============================================================================================================
        //public IEnumerable<string> SelectedSources { get; set; } . The actual Code first property will be ICollection of Object
        //public GetCountries()
        //{
        //    Countries = new SelectList(
        //        new[] { "Google", "TV", "Radio", "A friend", "Crazy bloke down the pub" });

        //    SelectedCountries = new[] { "Google" };
        //}
        //@foreach(var item in Model.GetCountries())
        //{
        //<input type = "checked" name = "SelectedSources" value = "@item" > @item
        //}
        //private IEnumerable<Country> GetCountryCB()
        //{
        //var FE = new FormEntities();
        //var countries = FE
        //            .Country
        //            .Select(x => new Country { CID = x.CID, CCDE = x.CCDE });
        //return countries;
        //}

        //Editor Template Implementation
        //    public class CheckBoxListItem
        //    {
        //        public int ID { get; set; }
        //        public string Display { get; set; }
        //        public bool IsChecked { get; set; }
        //    }
        //    Views/Shared/EditorTemplates/CheckBoxListItem.cshtml

        //@model CheckBoxListDemo.Web.Models.CheckBoxListItem

        //@Html.HiddenFor(x => x.ID)
        //@Html.CheckBoxFor(x => x.IsChecked)
        //@Html.LabelFor(x => x.IsChecked, Model.Display)
        //<br /> 
        //        public class AddMovieVM
        //    {
        //        public List<CheckBoxListItem> Genres { get; set; }

        //        public AddMovieVM()
        //        {
        //            Genres = new List<CheckBoxListItem>();
        //        }
        //    }
        //      <div>
        //            @Html.LabelFor(x => x.RunningTimeMinutes)
        //            @Html.TextBoxFor(x => x.RunningTimeMinutes)
        //        </div>
        //        <div>
        //            @Html.EditorFor(x => x.Genres)
        //        </div>
        //        [HttpGet]
        //    public ActionResult Add()
        //    {
        //        AddMovieVM model = new AddMovieVM();
        //        var allGenres = GenreManager.GetAll(); //returns List<Genre>
        //        var checkBoxListItems = new List<CheckBoxListItem>();
        //        foreach (var genre in allGenres)
        //        {
        //            checkBoxListItems.Add(new CheckBoxListItem()
        //            {
        //                ID = genre.ID,
        //                Display = genre.Name,
        //                IsChecked = false //On the add view, no genres are selected by default
        //            });
        //        }
        //        model.Genres = checkBoxListItems;
        //        return View(model);
        //    }


        //Radiobutton Lists
        //======================
        //This strongly Typed Datasource can be used for Radiobutton Lists  - Works in same way as Dropdownlist but with with 
        //manual DOM/Radiobutton element Construction repetetively like Listbox . so property to be used in the ViewModel is IEnumerable<string/Int>
        //=================================================================================================================
        //@foreach(var Rd in Model.SkillsetSources)
        //{
        //    @Html.RadioButtonFor(model => model.Prof.RadioEditorBox, Rd.ID) 
        //    @Html.Label(Rd.Name)
        //}

        //File Upload
        //=============
        //This strongly Typed Datasource can be used for File Upload 
        //=====================================================================================================================
        //        <form action = "" method="post" enctype="multipart/form-data">
        //         <label for="file">Filename:</label>
        //        <input type = "file" name="file" id="file" />
        //        <input type = "submit" />
        //        </ form >
        //            [HttpPost]
        //        public ActionResult Index(HttpPostedFileBase file)
        //        {
        //            if (file.ContentLength > 0)
        //            {
        //                var fileName = Path.GetFileName(file.FileName);
        //                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //                file.SaveAs(path);
        //            }
        //            return RedirectToAction("Index");
        //        }
        //        Uploading multiple files -  We can simply have multiple file inputs all with the same name.
        //        <form action = "" method= "post" enctype= "multipart/form-data" >
        //          < label for="file1">Filename:</label>
        //         <input type = "file" name= "files" id= "file1" />
        //         < label for="file2">Filename:</label>
        //         <input type = "file" name= "files" id= "file2" />
        //         < input type = "submit" />
        //        </ form >
        //            [HttpPost]
        //        public ActionResult Index(IEnumerable<HttpPostedFileBase> files)//Saving File in Filesystem and saving Location in DB
        //        {
        //            foreach (var file in files)
        //            {
        //                if (file.ContentLength > 0)
        //                {
        //                    var fileName = Path.GetFileName(file.FileName);
        //                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //                    file.SaveAs(path);
        //                }
        //            }
        //            return RedirectToAction("Index");
        //        }
        //        @using(Html.BeginForm("Create", "Student", null, FormMethod.Post, new {enctype = "multipart/form-data"})) 
        //        [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Student student, HttpPostedFileBase upload)
        // Saving file as stream of bytes in DB
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                if (upload != null && upload.ContentLength > 0)
        //                {
        //                    var avatar = new File
        //                    {
        //                        FileName = System.IO.Path.GetFileName(upload.FileName),
        //                        FileType = FileType.Avatar,
        //                        ContentType = upload.ContentType
        //                    };
        //                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
        //                    {
        //                        avatar.Content = reader.ReadBytes(upload.ContentLength);
        //                    }
        //                }
        //                db.Students.Add(student);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    //Displaying IMage
        //<img src = "@Url.Content("~/Content/images/myimage.png")" alt="@Model.AlternateText" />

        //       @if(Model.Files.Any(f => f.FileType == FileType.Avatar))
        //    {
        //        <dt>
        //            Avatar
        //        </dt>
        //        <dd>
        //            <img src = "~/File?id=@Model.Files.First(f => f.FileType == FileType.Avatar).FileId" alt="avatar" />
        //        </dd>
        //    }
        ////Downloading File with FileResult
        //public class FileController : Controller
        //{
        //    private SchoolContext db = new SchoolContext();
        //    //
        //    // GET: /File/
        //    public ActionResult Index(int id)
        //    {
        //        var fileToRetrieve = db.Files.Find(id);
        //        return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        //    }
        //}

        ////Strongly Typed File validation
        //    public class RegistrationModel
        //{
        //    [Required(ErrorMessage = "Please Enter Your Full Name")]
        //    [Display(Name = "Full Name")]
        //    public string Name { get; set; }
        //    [Required(ErrorMessage = "Please Enter Address")]
        //    [Display(Name = "Address")]
        //    [MaxLength(200)]
        //    public string Address { get; set; }
        //    [Required(ErrorMessage = "Please Upload File")]
        //    [Display(Name = "Upload File")]
        //    [ValidateFile]
        //    public HttpPostedFileBase file { get; set; }
        //}
        ////Customized data annotation validator for uploading file
        //public class ValidateFileAttribute : ValidationAttribute
        //{
        //    public override bool IsValid(object value)
        //    {
        //        int MaxContentLength = 1024 * 1024 * 3; //3 MB
        //        string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };
        //        var file = value as HttpPostedFileBase;
        //        if (file == null)
        //            return false;
        //        else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
        //        {
        //            ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", AllowedFileExtensions);
        //            return false;
        //        }
        //        else if (file.ContentLength > MaxContentLength)
        //        {
        //            ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "MB";
        //            return false;
        //        }
        //        else
        //            return true;
        //    }
        //}
        //[HttpPost]
        //public ActionResult FileUpload(RegistrationModel mRegister)
        //{
        //    //Check server side validation using data annotation
        //    if (ModelState.IsValid)
        //    {
        //        //TO:DO
        //        var fileName = Path.GetFileName(mRegister.file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
        //        mRegister.file.SaveAs(path);
        //        ViewBag.Message = "File has been uploaded successfully";
        //        ModelState.Clear();
        //    }
        //    return View();
        //}
        //@using(Html.BeginForm("FileUpload", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
        //{ 
        // @Html.LabelFor(m => m.Name)
        // @Html.TextBoxFor(m => m.Name, new { maxlength = 50 })
        // @Html.ValidationMessageFor(m => m.Name)

        // @Html.LabelFor(m => m.Address)
        // @Html.TextAreaFor(m => m.Address, new { maxlength = 200 })
        // @Html.ValidationMessageFor(m => m.Address)

        // @Html.TextBoxFor(m => m.file, new { type = "file" })
        // @Html.ValidationMessageFor(m => m.file)
        // <input type = "submit" value="Submit" />
        // </fieldset>
        //}

        //You cannot upload files using Ajax.BeginForm(). This is not supported. Instead can upload in Html.BeginForm()
        //        Increasing the Maximum Upload Size
        //The 4MB default is set in machine.config, but you can override it in you web.config.For instance, to expand the upload limit to 20MB, you'd do this:
        //<system.web>
        //  <httpRuntime executionTimeout = "240" maxRequestLength= "20480" />
        //</ system.web >
        //        <!-- IIS Specific Targeting(noted by the system.webServer section) -->
        //<system.webServer>
        //   <security>
        //      <requestFiltering>
        //         <!-- This will handle requests up to 1024MB(1GB) -->
        //         <requestLimits maxAllowedContentLength = "1048576000" />
        //      </ requestFiltering >
        //   </ security >
        // </ system.webServer >
    }

    //Server Side Validation - Data annotation for Checkbox
    //==========================================================
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidateCheckCollectionAttribute : ValidationAttribute//, IClientValidatable
    {
        //// Validation logic for server side goes here
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    // do some if else conditions

        //    return new ValidationResult("Server side validation message demo.");
        //}
        public override bool IsValid(object value)
        {
            return value != null && value is bool && (bool)value;
            //return base.IsValid(value);
        }
        //public override bool IsValid(object value)
        //{

        //    return value is bool && (bool)value;
        //    //if (value is bool)
        //    //    return (bool)value;
        //    //else
        //    //    return true;
        //}

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
        //    ModelMetadata metadata,
        //    ControllerContext context)
        //{
        //    yield return new ModelClientValidationRule
        //    {
        //        ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
        //        ValidationType = "booleanrequired"
        //    };
        //}
        //public override bool IsValid(object value)
        //{
        //    return value is bool && (bool)value;
        //    //return new ValidationResult("Server side validation message demo.");
        //}
        // Implement IClientValidatable for client side Validation 
        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    return new ModelClientValidationRule[] {
        //        new ModelClientValidationRule { ValidationType = "checkboxtrue", ErrorMessage = this.ErrorMessage } };
        //}
    }
}