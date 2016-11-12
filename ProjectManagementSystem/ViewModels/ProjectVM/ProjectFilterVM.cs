using DataAccess.Entity;
using ProjectManagementSystem.Filters;
using ProjectManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.ProjectVM
{
    public class ProjectFilterVM : FilterVM<Project>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }

        [FilterByAttribute(DisplayName = "Start Date:")]
        public DateTime StartDate { get; set; }

        [FilterByAttribute(DisplayName = "End Date:")]
        public DateTime EndDate { get; set; }

        [FilterByAttribute(DisplayName = "State:")]
        public string State { get; set; }
        public override Expression<Func<Project, bool>> GenerateFilter()
        {
            return (p => (p.TeamId == AuthenticationManager.LoggedEmployee.TeamId) && 
                         (String.IsNullOrEmpty(Name) || p.Name.Contains(Name)) &&
                         (String.IsNullOrEmpty(State) || p.Finished == (State.ToLower() == "finished" ? true : false)));
        }
    }
}