using DataAccess.Entity;
using DataAccess.Service;
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
        public string StartDate { get; set; }

        [FilterByAttribute(DisplayName = "End Date:")]
        public string EndDate { get; set; }

        [FilterByAttribute(DisplayName = "State:")]
        public string State { get; set; }

        [FilterByAttribute(DisplayName = "Team:")]
        public string Team { get; set; }
        public override Expression<Func<Project, bool>> GenerateFilter()
        {
            TeamService TeamService = new TeamService();
            int teamId = TeamService.GetAll(t => t.Name == Team).ToList().Count > 0 ? TeamService.GetAll(t => t.Name == Team).ToList()[0].Id : 0;

            DateTime startDate = Convert.ToDateTime(StartDate);
            DateTime endDate = Convert.ToDateTime(EndDate);

            return (p => (p.TeamId == AuthenticationManager.LoggedEmployee.TeamId) && 
                         (String.IsNullOrEmpty(Name) || p.Name.Contains(Name)) &&
                         (String.IsNullOrEmpty(Team) || p.TeamId == teamId) &&
                         (String.IsNullOrEmpty(StartDate) || p.StartDate == startDate) &&
                         (String.IsNullOrEmpty(EndDate) || p.StartDate == endDate) &&
                         (String.IsNullOrEmpty(State) || p.Finished == (State.ToLower() == "finish" ? true : false)));
        }
    }
}