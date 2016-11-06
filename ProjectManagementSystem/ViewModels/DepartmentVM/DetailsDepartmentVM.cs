using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.DepartmentVM
{
    public class DetailsDepartmentVM:BaseVMId
    {
        [Display(Name = "Department Name:")]
        public string Name { get; set; }

        [Display(Name = "Description:")]
        public string Description { get; set; }
    }
}