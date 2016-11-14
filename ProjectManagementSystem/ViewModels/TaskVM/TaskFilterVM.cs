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

        public override Expression<Func<Task, bool>> GenerateFilter()
        {
            return (p => (p.AssignetId == AuthenticationManager.LoggedEmployee.Id || p.CreatorId == AuthenticationManager.LoggedEmployee.Id) && 
                         (String.IsNullOrEmpty(Title) || p.Title.Contains(Title)) &&
                         (String.IsNullOrEmpty(Status) || p.Status == Status));
        }
    }
}