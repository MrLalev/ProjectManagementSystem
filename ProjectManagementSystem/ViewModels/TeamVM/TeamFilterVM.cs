using DataAccess.Entity;
using ProjectManagementSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.TeamVM
{
    public class TeamFilterVM : FilterVM<Team>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }
        public override Expression<Func<Team, bool>> GenerateFilter()
        {
            return (t => (String.IsNullOrEmpty(Name) || t.Name.Contains(Name)));
        }
    }
}