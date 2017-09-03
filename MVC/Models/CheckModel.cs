using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class CheckModel
    {
        [ValidateCheck(ErrorMessage = "TEST")]
        public IEnumerable<string> Checkboxlist { get; set; }

        public List<SelectListItem> Checkboxlistsources//CheckBoxlist Available options defined in View Model
        {
            get
            {
                return new List<SelectListItem>{ new SelectListItem { Text = "WEB", Value = "C#",Selected=false },
                 new SelectListItem { Text = "WINDOWS", Value = "WINDOWS" ,Selected=false},
                 new SelectListItem { Text = "API", Value = "API" ,Selected=false} };
            }
        }
        [Display(Name = "I accept the above terms and conditions.")]
        [CheckBoxRequired(ErrorMessage = "Please accept the terms and condition.")]
        public bool TermsConditions { get; set; }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidateCheckAttribute : ValidationAttribute//, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value is bool)
            {
                return (bool)value;
            }

            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "checkboxssssssssssrequired"
            };
        }
        //public override bool IsValid(object value)
        //{
        //    return value != null && value is bool && (bool)value;
        //    //return base.IsValid(value);
        //}

        //// Validation logic for server side goes here
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    // do some if else conditions

        //    return new ValidationResult("Server side validation message demo.");
        //}
    }

    public class CheckBoxRequired : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value is bool)
            {
                return (bool)value;
            }

            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "checkboxrequired"
            };
        }
    }
}