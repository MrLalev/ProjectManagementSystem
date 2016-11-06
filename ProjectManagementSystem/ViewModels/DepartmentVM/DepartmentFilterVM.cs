using DataAccess.Entity;
using ProjectManagementSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.DepartmentVM
{
    public class DepartmentFilterVM : FilterVM<Department>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }

        public override Expression<Func<Department, bool>> GenerateFilter()
        {
            return (d => (String.IsNullOrEmpty(Name) || d.Name.Contains(Name)));
        }
    }
}