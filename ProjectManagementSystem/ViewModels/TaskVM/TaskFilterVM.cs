using DataAccess.Entity;
using ProjectManagementSystem.Filters;
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
            return (p => (String.IsNullOrEmpty(Title) || p.Title.Contains(Title)) &&
                         (String.IsNullOrEmpty(Status) || p.Status == Status));
        }
    }
}