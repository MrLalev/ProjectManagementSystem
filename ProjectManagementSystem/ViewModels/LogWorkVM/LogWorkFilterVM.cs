using DataAccess.Entity;
using ProjectManagementSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.LogWorkVM
{
    public class LogWorkFilterVM : FilterVM<LogWork>
    {
        [FilterByAttribute(DisplayName = "WorkType:")]
        public string WorkType { get; set; }

        public override Expression<Func<LogWork, bool>> GenerateFilter()
        {
            return (l => (String.IsNullOrEmpty(WorkType) || l.WorkType.Contains(WorkType)));
        }
    }
}