using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Filters
{
    public class FilterByAttribute : Attribute
    {
        public string DisplayName { get; set; }
    }
}