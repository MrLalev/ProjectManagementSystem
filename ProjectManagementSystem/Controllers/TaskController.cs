﻿using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Filters;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.ViewModels;
using ProjectManagementSystem.ViewModels.CommentVM;
using ProjectManagementSystem.ViewModels.LogWorkVM;
using ProjectManagementSystem.ViewModels.TaskVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            if (model.ListStatus.Count() > 0)
            {
                model.ListStatus[0].Selected = true;
            }

        }

        public override void AddAdditionalInfo(ListTaskVM model)
        {
            ProjectService ProjectService = new ProjectService();
            model.projects = new string[model.Items.Count()];

            for (int i = 0; i < model.Items.Count(); i++)
            {
                try
                {
                    model.projects[i] = ProjectService.GetById(model.Items[i].ProjectId).Name;
                }
                catch (Exception)
                {                    
                    break;
                }

            }

            EmployeeService EmployeeService = new EmployeeService();
            model.creators = new string[model.Items.Count()];

            for (int i = 0; i < model.Items.Count(); i++)
            {
                model.creators[i] = EmployeeService.GetById(model.Items[i].CreatorId).FirstName + " " + EmployeeService.GetById(model.Items[i].CreatorId).LastName;
            }

            model.assignets = new string[model.Items.Count()];
            for (int i = 0; i < model.Items.Count(); i++)
            {
                if (model.Items[i].AssignetId != 0)
                {
                    model.assignets[i] = EmployeeService.GetById(model.Items[i].AssignetId).FirstName + " " + EmployeeService.GetById(model.Items[i].AssignetId).LastName;
                }
                else 
                {
                    model.assignets[i] = "";
                }
               
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
            task.LogWork = model.LogWork;
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
            model.LogWork = Convert.ToInt32(task.LogWork);
        }

        public override void PopulateModelDelete(Task task, DetailsTaskVM model)
        {
            model.Id = task.Id;
            model.Title = task.Title;
            EmployeeService EmployeeService = new EmployeeService();
            model.Assignet = task.AssignetId != 0 ? EmployeeService.GetById(task.AssignetId).FirstName + " " + EmployeeService.GetById(task.AssignetId).LastName : "";
            model.Creator = EmployeeService.GetById(task.CreatorId).FirstName + " " + EmployeeService.GetById(task.CreatorId).LastName;
            model.Content = task.Description;
            model.PercentageDone = task.PercentageDone;
            ProjectService ProjectService = new ProjectService();
            model.Project = ProjectService.GetById(task.ProjectId).Name;
            model.Status = task.Status;
            model.LogWork = Convert.ToInt32(task.LogWork);

            model.CommentsVM = new ListCommentVM();

            CommentService CommentService = new CommentService();
            List<Comment> comments = CommentService.GetAll(c => c.TaskId == model.Id).ToList();

            model.CommentsVM.Items = new List<Comment>();
            foreach (Comment item in comments)
            {
                model.CommentsVM.Items.Add(item);
            }
            CommentController commentCtrl = new CommentController();
            commentCtrl.AddAdditionalInfo(model.CommentsVM);

            model.CommentsVM.Pager = new PagerVM();
            model.CommentsVM.Filter = new CommentFilterVM();
            model.CommentsVM.Pager.Prefix = "CommentsVM.Pager.";
            model.CommentsVM.Filter.Prefix = "CommentsVM.Filter.";
            model.CommentsVM.Filter.Pager = model.CommentsVM.Pager;

            TryUpdateModel(model);

            model.CommentsVM.Pager.PagesCount = (int)Math.Ceiling(model.CommentsVM.Items.Count / (double)model.CommentsVM.Pager.PageSize);
            model.CommentsVM.Items = model.CommentsVM.Items.Skip(model.CommentsVM.Pager.PageSize * (model.CommentsVM.Pager.CurrentPage - 1)).Take(model.CommentsVM.Pager.PageSize).ToList();

            model.LogWorkVM = new ListLogWorkVM();

            LogWorkService LogWorkService = new LogWorkService();
            List<LogWork> logWork = LogWorkService.GetAll(l => l.TaskId == model.Id).ToList();

            model.LogWorkVM.Items = new List<LogWork>();
            foreach (LogWork item in logWork)
            {
                model.LogWorkVM.Items.Add(item);
            }

            LogWorkController LogWorkController = new LogWorkController();
            LogWorkController.AddAdditionalInfo(model.LogWorkVM);

            model.LogWorkVM.Pager = new PagerVM();
            model.LogWorkVM.Filter = new LogWorkFilterVM();
            model.LogWorkVM.Pager.Prefix = "LogWorkVM.Pager.";
            model.LogWorkVM.Filter.Prefix = "LogWorkVM.Filter.";
            model.LogWorkVM.Filter.Pager = model.LogWorkVM.Pager;

            TryUpdateModel(model);

            model.LogWorkVM.Pager.PagesCount = (int)Math.Ceiling(model.LogWorkVM.Items.Count / (double)model.LogWorkVM.Pager.PageSize);
            model.LogWorkVM.Items = model.LogWorkVM.Items.Skip(model.LogWorkVM.Pager.PageSize * (model.LogWorkVM.Pager.CurrentPage - 1)).Take(model.LogWorkVM.Pager.PageSize).ToList();
        }

        public override BaseService<Task> SetService()
        {
            return new TaskService();
        }
    }
}