using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.EntityFrameworkBoard.CodeFirst
{
    public class StandardDataAnnotation
    {
        [Key, ForeignKey("Student")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual SudentDataAnnotation Student { get; set; }
    }
}