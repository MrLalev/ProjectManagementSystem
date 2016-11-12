﻿using DataAccess.Entity;
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
                tasks = TaskService.GetAll(t=> t.ProjectId == item.Id).ToList();
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
                model.ListTask[0].Selected = true;
            }

        }
        public override void ExtraDelete(Comment comment)
        {
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
            model.TaskId = comment.TaskId;
            model.CreatorId = comment.CreatorId;
        }

        public override BaseService<Comment> SetService()
        {
            return new CommentService();
        }
    }
}