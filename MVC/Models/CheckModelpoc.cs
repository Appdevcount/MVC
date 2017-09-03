using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CheckModelpoc
    {
        [CheckList(1, false, ErrorMessage = "TEST")]
        public List<string> StaticMultiBoxes { get; set; }

        [CheckList(2, true,ErrorMessage ="TEST")]
        public List<int> DynamicMultiBoxes { get; set; }
        //public string sChecked(string input)
        //{
        //    string ck = "";
        //    if (this.StaticMultiBoxes != null && this.StaticMultiBoxes.Count > 0)
        //    {
        //        if (this.StaticMultiBoxes.Contains(input))
        //        {
        //            ck = "checked=\"checked\"";
        //        }
        //    }
        //    return ck;
        //}
        //public string dChecked(int input)
        //{
        //    string ck = "";
        //    if (this.DynamicMultiBoxes != null && this.DynamicMultiBoxes.Count > 0)
        //    {
        //        if (this.DynamicMultiBoxes.Contains(input))
        //        {
        //            ck = "checked=\"checked\"";
        //        }
        //    }
        //    return ck;
        //}
        //http://www.nwa4.com/blog/asp.net-mvc-multiple-checkboxes-validation-and-handling-using-c-sharp
    }
    public class CheckListAttribute : ValidationAttribute
    {
        int _length;
        bool _fixed;

        public override bool IsValid(object value)
        {
            int l = 0;

            if (value != null && typeof(List<int>) == value.GetType())
            {
                var v = (List<int>)value;
                l = v.Count;
            }
            else if (value != null)
            {
                var v = (List<string>)value;
                l = v.Count;
            }

            if (this._fixed)
            {
                return value != null && this._length == l;
            }
            else
            {
                return value != null && l >= this._length;
            }
        }

        public CheckListAttribute(int length = 1, bool isFixed = false)
        {

            this._length = length;
            this._fixed = isFixed;
        }

    }

}