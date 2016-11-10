using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProjectManagementSystem.ValidationAttributes
{
    public class EmailAttribute : ValidationAttribute
    {
        private string targetProperty;

        public EmailAttribute(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value.ToString() == "") 
            {
                return new ValidationResult("E-mail is required!");
            }

            try
            {
                MailAddress m = new MailAddress(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult("Invalid E-mail!");
            }

            return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            return String.IsNullOrEmpty(this.ErrorMessage);
        }
    }
}