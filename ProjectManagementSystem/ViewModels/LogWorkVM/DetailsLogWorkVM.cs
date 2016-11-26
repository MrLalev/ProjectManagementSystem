using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.LogWorkVM
{
    public class DetailsLogWorkVM : BaseVMId
    {
        [Display(Name = "Employee: ")]
        public string Employee { get; set; }

        [Display(Name = "Work Type: ")]
        public string WorkType { get; set; }

        [Display(Name = "Hours Worked: ")]
        public int HoursWorked { get; set; }

    }
}