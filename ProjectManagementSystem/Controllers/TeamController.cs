using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.ViewModels.TeamVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class TeamController : BaseController<Team, ListTeamVM, EditTeamVM, DetailsTeamVM, TeamFilterVM>
    {
        public override void ExtraDelete(Team team)
        {
           
        }

        public override void PopulateItem(Team team, EditTeamVM model)
        {
            team.Id = model.Id;
            team.Name = model.Name;
            team.DepartmentId = model.DepartmentId;
        }

        public override void PopulateModel(Team team, EditTeamVM model)
        {
            model.Id = team.Id;
            model.Name = team.Name;
            model.DepartmentId = team.DepartmentId;
        }

        public override void PopulateModelDelete(Team team, DetailsTeamVM model)
        {
            model.Id = team.Id;
            model.Name = team.Name;
            model.DepartmentId = team.DepartmentId;
        }

        public override BaseService<Team> SetService()
        {
            return new TeamService();
        }
    }
}