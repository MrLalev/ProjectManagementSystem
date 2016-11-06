using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.DepartmentVM
{
    public class EditDepartmentVM:BaseVMId
    {
        [Required(ErrorMessage = "Please enter Department Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}