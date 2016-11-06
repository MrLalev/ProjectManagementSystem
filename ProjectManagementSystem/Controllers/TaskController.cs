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

            model.ListProjects[0].Selected = true;

            EmployeeService EmployeeService = new EmployeeService();
            List<Employee> managers = EmployeeService.GetAll().ToList();

            model.ListAssignet = new List<SelectListItem>();
            model.ListAssignet.Add(new SelectListItem() { Text = "", Value = null });
            foreach (var item in managers)
            {
                if (item.Id != AuthenticationManager.LoggedEmployee.Id)
                {
                    model.ListAssignet.Add(new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName,
                        Value = item.Id.ToString()
                    });
                }

            }

            model.ListAssignet[0].Selected = true;
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