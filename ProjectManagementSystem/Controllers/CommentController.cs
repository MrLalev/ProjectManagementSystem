using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.ViewModels.CommentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class CommentController : BaseController<Comment, ListCommentVM, EditCommentVM, DetailsCommentVM, CommentFilterVM>
    {
        public override void FillList(EditCommentVM model)
        {
            TaskService TaskService = new TaskService();
            ProjectService ProjectService = new ProjectService();
            List<Project> projects = ProjectService.GetAll(p => p.TeamId == AuthenticationManager.LoggedEmployee.TeamId).ToList();
            List<Task> tasks = new List<Task>();

            foreach (var item in projects)
            {
                foreach (var task in TaskService.GetAll(t => t.ProjectId == item.Id).ToList())
                {
                    tasks.Add(task);
                }
            }

            model.ListTask = new List<SelectListItem>();
            foreach (var item in tasks)
            {
                model.ListTask.Add(new SelectListItem()
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                });

            }


            if (model.ListTask.Count() > 0)
            {
                if (model.TaskId != 0)
                {
                    model.ListTask.Find(p => p.Value == model.TaskId.ToString()).Selected = true;
                }
                else
                {
                    model.ListTask[0].Selected = true;
                }

            }
        }
        public override void ExtraDelete(Comment comment)
        {
        }
        public override void AddAdditionalInfo(ListCommentVM model)
        {
            TaskService TaskService = new TaskService();
            model.tasks = new string[model.Items.Count()];

            for (int i = 0; i < model.Items.Count(); i++)
            {
                model.tasks[i] = TaskService.GetById(model.Items[i].TaskId).Title;
            }

            EmployeeService EmployeeService = new EmployeeService();
            model.creators = new string[model.Items.Count()];

            for (int i = 0; i < model.Items.Count(); i++)
            {
                model.creators[i] = EmployeeService.GetById(model.Items[i].CreatorId).FirstName + " " + EmployeeService.GetById(model.Items[i].CreatorId).LastName;
            }
        }
        public override void PopulateItem(Comment comment, EditCommentVM model)
        {
            comment.Id = model.Id;
            comment.Title = model.Title;
            comment.Content = model.Content;
            comment.TaskId = model.TaskId;
            comment.CreatorId = AuthenticationManager.LoggedEmployee.Id;
        }

        public override void PopulateModel(Comment comment, EditCommentVM model)
        {
            model.Id = comment.Id;
            model.Title = comment.Title;
            model.Content = comment.Content;
            model.TaskId = comment.TaskId;
        }

        public override void PopulateModelDelete(Comment comment, DetailsCommentVM model)
        {
            model.Id = comment.Id;
            model.Title = comment.Title;
            model.Content = comment.Content;
            TaskService TaskService = new TaskService();
            model.Task = TaskService.GetById(comment.TaskId).Title;
            EmployeeService EmployeeService = new EmployeeService();
            model.Creator = EmployeeService.GetById(comment.CreatorId).FirstName + " " + EmployeeService.GetById(comment.CreatorId).LastName;
        }

        public override BaseService<Comment> SetService()
        {
            return new CommentService();
        }
    }
}