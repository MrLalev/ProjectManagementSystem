using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ValidationAttributes
{
    public class UniqueEmail : ValidationAttribute
    {
        private string targetProperty;

        public UniqueEmail(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.targetProperty);
            var referenceProperty = (int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            EmployeeRepo EmployeeRepo = new EmployeeRepo();
            List<Employee> Employees = EmployeeRepo.GetAll().ToList();
            Employee editEmployee = EmployeeRepo.GetById(referenceProperty);


            if (editEmployee != null)
            {
                foreach (var item in Employees)
                {
                    if (item.Email == value.ToString() && editEmployee.Email != value.ToString())
                    {
                        return new ValidationResult("This E-mail already exists!");
                    }
                }
            }
            else
            {
                foreach (var item in Employees)
                {
                    if (item.Email == value.ToString())
                    {
                        return new ValidationResult("This E-mail already exists!");
                    }
                }
            }


            return base.IsValid(value, validationContext);
        }

        public override bool IsValid(object value)
        {
            return String.IsNullOrEmpty(this.ErrorMessage);
        }
    }
}