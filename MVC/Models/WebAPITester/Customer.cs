using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.WebAPITester
{
    public partial class Customer
    {
        //[Display(Name = "CustomerId")]
        public int CustId { get; set; }
        //[Display(Name = "Name")]
        public string Name { get; set; }
        //[Display(Name = "Address")]
        public string Address { get; set; }
        //[Display(Name = "MobileNo")]
        public string Contact { get; set; }
        //[Display(Name = "Birthdate")]
        //[DataType(DataType.DateTime)]
        public DateTime? Birthdate { get; set; }
        //[Display(Name = "EmailId")]
        public string Email { get; set; }
    }
}