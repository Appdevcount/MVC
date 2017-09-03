using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.EntityFrameworkBoard.CodeFirst
{
    public class CFStudent
    {
        public CFStudent()
        {

        }
        public int StudentID { get; set; }//Default PK convention class+Id 
        //public int StdID { get; set; }// PK convention  +Id
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public string Address { get; set; }

        //Navigation Property - By default EF Convention, FK automatically created as Navprop+NavpropPK
        public CFStandard Standard { get; set; }
        //public int CFStandardId { get; set; }//or we can explicitly mention FK as NavpropPK
    }
}