using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Filters
{
    public class FilterDropDownAttribute : FilterByAttribute
    {
        public string TargetProperty { get; set; }
    }
}