using DataAccess.Entity;
using ProjectManagementSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.Project_ReportVM
{
    public class Project_ReportFilterVM : FilterVM<Project_Report>
    {
        [FilterByAttribute(DisplayName = "Title:")]
        public string Title { get; set; }

        public override Expression<Func<Project_Report, bool>> GenerateFilter()
        {
            return (r => (String.IsNullOrEmpty(Title) || r.Title.Contains(Title)));
        }
    }
}