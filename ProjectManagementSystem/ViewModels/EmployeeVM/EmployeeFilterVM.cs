using DataAccess.Entity;
using ProjectManagementSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.EmployeeVM
{
    public class EmployeeFilterVM : FilterVM<Employee>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }
        [FilterByAttribute(DisplayName = "Email:")]
        public string Email { get; set; }

        public override Expression<Func<Employee, bool>> GenerateFilter()
        {
            return (u => (String.IsNullOrEmpty(Name) || u.FirstName.Contains(Name)) &&
                         (String.IsNullOrEmpty(Name) || u.LastName.Contains(Name)) &&
                         (String.IsNullOrEmpty(Email) || u.Email.Contains(Email)));
        }
    }
}