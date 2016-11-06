using DataAccess.Entity;
using ProjectManagementSystem.Filters;
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
            return (p => (String.IsNullOrEmpty(Name) || p.Name.Contains(Name)) &&
                         (String.IsNullOrEmpty(Convert.ToString(StartDate)) || p.StartDate == StartDate) &&
                         (String.IsNullOrEmpty(Convert.ToString(EndDate)) || p.EndDate == EndDate) &&
                         (String.IsNullOrEmpty(State) || p.Finished == (State.ToLower() == "finished" ? true : false)));
        }
    }
}