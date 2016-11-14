using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.ViewModels;
using ProjectManagementSystem.ViewModels.CommentVM;
using ProjectManagementSystem.ViewModels.Project_ReportVM;
using ProjectManagementSystem.ViewModels.ProjectVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public override void AddAdditionalInfo(ListProjectVM model)
        {
            TeamService TeamService = new TeamService();
            model.teams = new string[model.Items.Count()];

            for (int i = 0; i < model.Items.Count(); i++)
            {
                model.teams[i] = TeamService.GetById(model.Items[i].TeamId).Name;
            }
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
            TeamService TeamService = new TeamService();
            model.Team = TeamService.GetById(project.TeamId).Name;
            model.Finished = project.Finished;


            model.Project_ReportVM = new ListProject_ReportVM();

            Project_ReportService Project_ReportService = new Project_ReportService();
            List<Project_Report> reports = Project_ReportService.GetAll(c => c.ProjectId == model.Id).ToList();

            model.Project_ReportVM.Items = new List<Project_Report>();
            foreach (Project_Report item in reports)
            {
                model.Project_ReportVM.Items.Add(item);
            }

            Project_ReportController reportsCtrl = new Project_ReportController();
            reportsCtrl.AddAdditionalInfo(model.Project_ReportVM);

            model.Project_ReportVM.Pager = new PagerVM();
            model.Project_ReportVM.Filter = new Project_ReportFilterVM();
            model.Project_ReportVM.Pager.Prefix = "Project_ReportVM.Pager.";
            model.Project_ReportVM.Filter.Prefix = "Project_ReportVM.Filter.";
            model.Project_ReportVM.Filter.Pager = model.Project_ReportVM.Pager;

            TryUpdateModel(model);

            model.Project_ReportVM.Pager.PagesCount = (int)Math.Ceiling(model.Project_ReportVM.Items.Count / (double)model.Project_ReportVM.Pager.PageSize);
            model.Project_ReportVM.Items = model.Project_ReportVM.Items.Skip(model.Project_ReportVM.Pager.PageSize * (model.Project_ReportVM.Pager.CurrentPage - 1)).Take(model.Project_ReportVM.Pager.PageSize).ToList();
        
        }

        public override BaseService<Project> SetService()
        {
            return new ProjectService();
        }
    }
}