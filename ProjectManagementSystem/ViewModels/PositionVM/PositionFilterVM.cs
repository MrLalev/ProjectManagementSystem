using DataAccess.Entity;
using ProjectManagementSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.PositionVM
{
    public class PositionFilterVM : FilterVM<Position>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }

        [FilterByAttribute(DisplayName = "Salary:")]
        public string Salary { get; set; }
        public override Expression<Func<Position, bool>> GenerateFilter()
        {
            return (p => (String.IsNullOrEmpty(Name) || p.Name.Contains(Name)) &&
                         (String.IsNullOrEmpty(Salary) || p.Salary >= Convert.ToDecimal(Salary)));
        }
    }
}