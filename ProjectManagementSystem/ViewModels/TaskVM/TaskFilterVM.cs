using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Filters;
using ProjectManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.TaskVM
{
    public class TaskFilterVM : FilterVM<Task>
    {
        [FilterByAttribute(DisplayName = "Title:")]
        public string Title { get; set; }

        [FilterByAttribute(DisplayName = "Status:")]
        public string Status { get; set; }

        [FilterByAttribute(DisplayName = "Project:")]
        public string Project { get; set; }

        public override Expression<Func<Task, bool>> GenerateFilter()
        {
            ProjectService ProjectService = new ProjectService();
            int projectId = ProjectService.GetAll(p => p.Name == Project).ToList().Count > 0 ? ProjectService.GetAll(p => p.Name == Project).ToList()[0].Id : 0;


            return (p => (p.AssignetId == AuthenticationManager.LoggedEmployee.Id || p.CreatorId == AuthenticationManager.LoggedEmployee.Id) &&
                          (String.IsNullOrEmpty(Title) || p.Title.Contains(Title)) &&
                          (String.IsNullOrEmpty(Project) || p.ProjectId == projectId) &&
                          (String.IsNullOrEmpty(Status) || p.Status == Status));
        }
    }
}