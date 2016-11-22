using DataAccess.Entity;
using DataAccess.Service;
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
        [FilterByAttribute(DisplayName = "First Name:")]
        public string FirstName { get; set; }

        [FilterByAttribute(DisplayName = "Last Name:")]
        public string LastName { get; set; }
        [FilterByAttribute(DisplayName = "Email:")]
        public string Email { get; set; }

        [FilterByAttribute(DisplayName = "Position:")]
        public string Position { get; set; }

        [FilterByAttribute(DisplayName = "Team:")]
        public string Team { get; set; }
        public override Expression<Func<Employee, bool>> GenerateFilter()
        {
            PositionService PositionService = new PositionService();
            int positionId = PositionService.GetAll(p => p.Name == Position).ToList().Count > 0 ? PositionService.GetAll(p => p.Name == Position).ToList()[0].Id : 0;

            TeamService TeamService = new TeamService();
            int teamId = TeamService.GetAll(t => t.Name == Team).ToList().Count > 0 ? TeamService.GetAll(t => t.Name == Team).ToList()[0].Id : 0;

            return (u => (String.IsNullOrEmpty(FirstName) || u.FirstName.Contains(FirstName)) &&
                         (String.IsNullOrEmpty(LastName) || u.LastName.Contains(LastName)) &&
                         (String.IsNullOrEmpty(Position) || u.PositionId == positionId) &&
                         (String.IsNullOrEmpty(Team) || u.TeamId == teamId) &&
                         (String.IsNullOrEmpty(Email) || u.Email.Contains(Email)));
        }
    }
}