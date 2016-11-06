using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.ViewModels.ProjectVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectController : BaseController<Project, ListProjectVM, EditProjectVM, DetailsProjectVM, ProjectFilterVM>
    {
        public override void FillList(EditProjectVM model)
        {
            TeamService TeamService = new TeamService();
            List<Team> teams = TeamService.GetAll().ToList();

            model.ListTeams = new List<SelectListItem>();
            foreach (var item in teams)
            {
                model.ListTeams.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });

            }

            model.ListTeams[0].Selected = true;
        }
        public override void ExtraDelete(Project project)
        {
            TaskService TaskService = new TaskService();
            List<Task> tasks = TaskService.GetAll(t => t.ProjectId == project.Id).ToList();

            foreach (var item in tasks)
            {
                CommentService CommentService = new CommentService();
                List<Comment> comments = CommentService.GetAll(c => c.TaskId == item.Id).ToList();

                foreach (var coment in comments)
                {
                    CommentService.Delete(coment);
                }

                TaskService.Delete(item);
            }

            Project_ReportService Project_ReportService = new Project_ReportService();
            List<Project_Report> Project_Reports = Project_ReportService.GetAll(r => r.ProjectId == project.Id).ToList();

            foreach (var Project_Report in Project_Reports)
            {
                Project_ReportService.Delete(Project_Report);
            }
        }

        public override void PopulateItem(Project project, EditProjectVM model)
        {
            project.Id = model.Id;
            project.Name = model.Name;
            project.StartDate = model.StartDate;
            project.EndDate = model.EndDate;
            project.TeamId = model.TeamId;
            project.Finished = model.Finished;
        }

        public override void PopulateModel(Project project, EditProjectVM model)
        {
            model.Id = project.Id;
            model.Name = project.Name;
            model.StartDate = project.StartDate;
            model.EndDate = project.EndDate;
            model.TeamId = project.TeamId;
            model.Finished = project.Finished; 
        }

        public override void PopulateModelDelete(Project project, DetailsProjectVM model)
        {
            model.Id = project.Id;
            model.Name = project.Name;
            model.StartDate = project.StartDate;
            model.EndDate = project.EndDate;
            model.TeamId = project.TeamId;
            model.Finished = project.Finished; 
        }

        public override BaseService<Project> SetService()
        {
            return new ProjectService();
        }
    }
}