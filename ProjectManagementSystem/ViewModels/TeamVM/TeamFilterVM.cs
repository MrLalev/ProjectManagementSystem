using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.TeamVM
{
    public class TeamFilterVM : FilterVM<Team>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }

        [FilterByAttribute(DisplayName = "Department:")]
        public string Department { get; set; }

        public override Expression<Func<Team, bool>> GenerateFilter()
        {
            DepartmentService DepartmentService = new DepartmentService();
            int departmentId = DepartmentService.GetAll(d => d.Name == Department).ToList().Count > 0 ? DepartmentService.GetAll(d => d.Name == Department).ToList()[0].Id : 0;

            return (t => (String.IsNullOrEmpty(Name) || t.Name.Contains(Name)) &&
                        (String.IsNullOrEmpty(Department) || t.DepartmentId == departmentId));
        }
    }
}