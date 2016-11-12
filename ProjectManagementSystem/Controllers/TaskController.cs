using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.ViewModels.TaskVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class TaskController : BaseController<Task, ListTaskVM, EditTaskVM, DetailsTaskVM, TaskFilterVM>
    {
        public override void FillList(EditTaskVM model)
        {
            ProjectService ProjectService = new ProjectService();
            List<Project> projects = ProjectService.GetAll(p => p.TeamId == AuthenticationManager.LoggedEmployee.TeamId).ToList();

            model.ListProjects = new List<SelectListItem>();
            foreach (var item in projects)
            {
                model.ListProjects.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });

            }
            if (model.ListProjects.Count() > 0)
            {
                model.ListProjects[0].Selected = true;
            }

            EmployeeService EmployeeService = new EmployeeService();
            List<Employee> assignets = EmployeeService.GetAll(e => e.TeamId == AuthenticationManager.LoggedEmployee.TeamId).ToList();

            model.ListAssignet = new List<SelectListItem>();
            model.ListAssignet.Add(new SelectListItem() { Text = "---", Value = "0" });
            foreach (var item in assignets)
            {
                model.ListAssignet.Add(new SelectListItem()
                {
                    Text = item.FirstName + " " + item.LastName,
                    Value = item.Id.ToString()
                });
            }
            if (model.ListAssignet.Count() > 0)
            {
                model.ListAssignet[0].Selected = true;
            }

            model.ListPercentage = new List<SelectListItem>();
            for (int i = 0; i <= 100; i+=10)
            {
                model.ListPercentage.Add(new SelectListItem()
                {
                    Text = i.ToString() + " %",
                    Value = i.ToString()
                });
            }
            if (model.ListPercentage.Count() > 0)
            {
                model.ListPercentage[0].Selected = true;
            }

            model.ListStatus = new List<SelectListItem>();
            model.ListStatus.Add(new SelectListItem() { Text = "New", Value = "New" });
            model.ListStatus.Add(new SelectListItem() { Text = "In Progress", Value = "In Progress" });
            model.ListStatus.Add(new SelectListItem() { Text = "Resolved", Value = "Resolved" });
            model.ListStatus.Add(new SelectListItem() { Text = "Closed", Value = "Closed" });
            model.ListStatus.Add(new SelectListItem() { Text = "Reopened", Value = "Reopend" });

            if (model.ListPercentage.Count() > 0)
            {
                model.ListPercentage[0].Selected = true;
            }
        }
        public override void ExtraDelete(Task task)
        {
            CommentService CommentService = new CommentService();
            List<Comment> comments = CommentService.GetAll(c => c.TaskId == task.Id).ToList();

            foreach (var coment in comments)
            {
                CommentService.Delete(coment);
            }
        }

        public override void PopulateItem(Task task, EditTaskVM model)
        {
            task.Id = model.Id;
            task.Title = model.Title;
            task.AssignetId = model.AssignetId;
            task.CreatorId = AuthenticationManager.LoggedEmployee.Id;
            task.Description = model.Content;
            task.PercentageDone = model.PercentageDone;
            task.ProjectId = model.ProjectId;
            task.Status = model.Status;
        }

        public override void PopulateModel(Task task, EditTaskVM model)
        {
            model.Id = task.Id;
            model.Title = task.Title;
            model.AssignetId = task.AssignetId;
            model.Content = task.Description;
            model.PercentageDone = task.PercentageDone;
            model.ProjectId = task.ProjectId;
            model.Status = task.Status;
        }

        public override void PopulateModelDelete(Task task, DetailsTaskVM model)
        {
            model.Id = task.Id;
            model.Title = task.Title;
            model.AssignetId = task.AssignetId;
            model.CreatorId = task.CreatorId;
            model.Content = task.Description;
            model.PercentageDone = task.PercentageDone;
            model.ProjectId = task.ProjectId;
            model.Status = task.Status;
        }

        public override BaseService<Task> SetService()
        {
            return new TaskService();
        }
    }
}