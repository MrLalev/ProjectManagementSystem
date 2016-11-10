using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ValidationAttributes
{
    public class DateAttribute : ValidationAttribute
    {
        private string targetProperty;

        public DateAttribute(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult("Date is required!");
            }
    
            if (Convert.ToDateTime(value.ToString()) > DateTime.Now.AddYears(-18))
            {
                return new ValidationResult("This Date is not valid!");
            }
            else if (Convert.ToDateTime(value.ToString()) < DateTime.Now.AddYears(-100))
            {
                return new ValidationResult("This Date is not valid!");
            }

            return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            return String.IsNullOrEmpty(this.ErrorMessage);
        }
    }
}